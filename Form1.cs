using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using static System.Windows.Forms.DataFormats;

namespace EQ2MapTools
{
    public partial class Form1 : Form
    {

        MapData mapData = new MapData();        // most of the zone rect calculations
        Mapper2 mapper2 = new Mapper2();        // most of the Perl script translations
        LineIndex lineIndex = new LineIndex();  // the line index data
        MapStyles mapStyles = new MapStyles();  // map sytles combo box data
        XmlDocument? doc;                       // the svg file
        bool userChange = false;                // whether a UI element is updated programtically or by the user
        public const int DefaultMapWidth = 436;
        public const int DefaultMapHeight = 506;
        Int64 startUnixSeconds = -1;                   // time filter for the log file
        Int64 endUnixSeconds = Int64.MaxValue;         // time filter for the log file
        // extract the 4 numbers from a zone rect
        Regex reZoneRect = new Regex(@"(?<ulx>[0-9.+-]+)[, ]+(?<uly>[0-9.+-]+)[, ]+(?<lrx>[0-9.+-]+)[, ]+(?<lry>[0-9.+-]+)", RegexOptions.Compiled);

        // keep a status line for each tab
        const string needInput = "Please provide necessary inputs.";
        const string ready = "Ready";
        string mapperTabStatus = needInput;
        string zonerectTabStatus = needInput;
        string maplocTabStatus = needInput;
        string indexTabStatus = "Run Mapper to build an index.";
        // consolodate tab nickname & index
        Dictionary<string, int> tabIndexes = new Dictionary<string, int>();

        // github update
        const string githubProject = "EQ2MapTools";
        const string githubOwner = "jeffjl74";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // could not figure a way to do this that would survive refactoring the tab page names
            // but at least this puts it all in one place
            tabIndexes.Add("mapper", tabControl1.TabPages.IndexOfKey("tabPageMapper"));
            tabIndexes.Add("zonerect", tabControl1.TabPages.IndexOfKey("tabPageZoneRect"));
            tabIndexes.Add("maploc", tabControl1.TabPages.IndexOfKey("tabPageMapLoc"));
            tabIndexes.Add("index", tabControl1.TabPages.IndexOfKey("tabPageLines"));
            tabIndexes.Add("help", tabControl1.TabPages.IndexOfKey("tabPageHelp"));

            richTextBox2.Rtf = Properties.Settings.Default.Help;
            textBoxLogFile.Text = Properties.Settings.Default.LogFile;
            ScrollToEnd(textBoxLogFile);
            textBoxOutputFolder.Text = Properties.Settings.Default.OutputFolder;
            ScrollToEnd(textBoxOutputFolder);
            if (Properties.Settings.Default.BaseMapName.Length > 0)
            {
                textBoxMapName.Text = Properties.Settings.Default.BaseMapName;
                textBoxMapName.ForeColor = Color.Black;
            }
            if (Properties.Settings.Default.MapLevel.Length > 0)
                textBoxMapLevel.Text = Properties.Settings.Default.MapLevel;
            if (Properties.Settings.Default.Elevations.Length > 0)
                textBoxElevations.Text = Properties.Settings.Default.Elevations;
            if (Properties.Settings.Default.SvgViewer1.Length > 0)
                textBoxInkscapeName.Text = Properties.Settings.Default.SvgViewer1;
            if (Properties.Settings.Default.SvgViewer2.Length > 0)
                textBoxDefaultSvgName.Text = Properties.Settings.Default.SvgViewer2;
            else
            {
                string? defaultSvgExePath = FileAssociation.GetExecFileAssociatedToExtension(".svg", "open");
                string? defaultSvgExe = Path.GetFileName(defaultSvgExePath);
                if (defaultSvgExe != null)
                    textBoxDefaultSvgName.Text = defaultSvgExe;
            }
            if (Properties.Settings.Default.MapStyleFile.Length > 0
                && Properties.Settings.Default.AutoLoadStyles)
            {
                OpenMapStyles(Properties.Settings.Default.MapStyleFile);
            }
            checkBoxLoadMapstyles.Checked = Properties.Settings.Default.AutoLoadStyles;

            if (Properties.Settings.Default.WindowLoc != Point.Empty)
            {
                Point clientPt = Properties.Settings.Default.WindowLoc;
                //make sure it fits on screen
                if (clientPt.X < 0)
                    clientPt.X = 0;
                if (clientPt.X + this.Size.Width > SystemInformation.VirtualScreen.Right)
                    clientPt.X = SystemInformation.VirtualScreen.Right - this.Size.Width;
                if (clientPt.Y < 0)
                    clientPt.Y = 0;
                if (clientPt.Y + this.Size.Height > SystemInformation.WorkingArea.Bottom)
                    clientPt.Y = SystemInformation.WorkingArea.Bottom - this.Size.Height;
                this.Location = clientPt;
            }

            // individual textbox databindings are set in the designer
            mapDataBindingSource.DataSource = mapData;

            // map styles binding
            mapStylesBindingSource.DataSource = mapStyles;
            comboBoxMapStyles.DisplayMember = "DisplayName";
            comboBoxMapStyles.DataSource = mapStylesBindingSource;

            // line index binding
            lineIndexBindingSource.DataSource = lineIndex;

            FixButtons();

            // starts up on mapper tab
            toolStripStatusLabel1.Text = mapperTabStatus;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CheckForProgramUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                Properties.Settings.Default.WindowLoc = this.Location;
            Properties.Settings.Default.LogFile = textBoxLogFile.Text;
            Properties.Settings.Default.OutputFolder = textBoxOutputFolder.Text;
            Properties.Settings.Default.BaseMapName = textBoxMapName.Text;
            Properties.Settings.Default.MapLevel = textBoxMapLevel.Text;
            Properties.Settings.Default.Elevations = textBoxElevations.Text;
            Properties.Settings.Default.SvgViewer1 = textBoxInkscapeName.Text;
            Properties.Settings.Default.SvgViewer2 = textBoxDefaultSvgName.Text;
            if (!string.IsNullOrEmpty(openFileDialogXml.FileName))
                Properties.Settings.Default.MapStyleFile = openFileDialogXml.FileName;
            Properties.Settings.Default.AutoLoadStyles = checkBoxLoadMapstyles.Checked;

            Properties.Settings.Default.Save();
        }

        private void FixButtons()
        {
            buttonRunMapper.Enabled = false;    // until we figure out if we're ready

            buttonFindMapName.Enabled = false;
            buttonScanDates.Enabled = false;
            bool logFileExists = false;
            if (textBoxLogFile.Text.Length > 0)
            {
                logFileExists = File.Exists(textBoxLogFile.Text);
                if (logFileExists)
                {
                    buttonFindMapName.Enabled = true;
                    buttonScanDates.Enabled = true;
                }
            }

            bool mapperExists = false;
            if (textBoxMapName.ForeColor == Color.Black)
            {
                string mapperFileName = BuildOutputName("txt");
                mapperExists = File.Exists(mapperFileName);
            }
            if (!mapperExists)
            {
                radioButtonAppendMapper.Enabled = false;
                radioButtonExistingMapper.Enabled = false;
                radioButtonBuildMapper.Checked = true;
            }
            else
            {
                radioButtonAppendMapper.Enabled = true;
                radioButtonExistingMapper.Enabled = true;
            }

            if (Directory.Exists(textBoxOutputFolder.Text))
            {
                if ((radioButtonBuildMapper.Checked || radioButtonAppendMapper.Checked)
                    && logFileExists && !string.IsNullOrEmpty(textBoxMapName.Text))
                {
                    buttonRunMapper.Enabled = true;
                    mapperTabStatus = ready;
                }
                else if (mapperExists && radioButtonExistingMapper.Checked)
                {
                    buttonRunMapper.Enabled = true;
                    mapperTabStatus = ready;
                }
            }
            else
                mapperTabStatus = needInput;


            if (!string.IsNullOrEmpty(textBoxMapLocX.Text)
                && !string.IsNullOrEmpty(textBoxMapLocY.Text)
                && !string.IsNullOrEmpty(textBoxMapLocZoneRect.Text)
                && !string.IsNullOrEmpty(textBoxMapLocWidth.Text)
                && !string.IsNullOrEmpty(textBoxMapLocHeight.Text))
            {
                buttonMapLocCalc.Enabled = true;
                maplocTabStatus = ready;
            }
            else
            {
                buttonMapLocCalc.Enabled = false;
                maplocTabStatus = needInput;
            }

        }

        private void UpdateStatusLine()
        {
            if (tabControl1.SelectedIndex == tabIndexes["mapper"])
            {
                toolStripStatusLabel1.Text = mapperTabStatus;
            }
            else if (tabControl1.SelectedIndex == tabIndexes["zonerect"])
            {
                toolStripStatusLabel1.Text = zonerectTabStatus;
            }
            else if (tabControl1.SelectedIndex == tabIndexes["maploc"])
            {
                toolStripStatusLabel1.Text = maplocTabStatus;
            }
            else if (tabControl1.SelectedIndex == tabIndexes["index"])
            {
                toolStripStatusLabel1.Text = indexTabStatus;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatusLine();
        }

        #region Github update

        private void CheckForProgramUpdate()
        {
            try
            {
                Version? localVersion = this.GetType().Assembly.GetName().Version;
                if (localVersion == null) return;
                this.Text += $" Version {localVersion}";
                Task<Version> vtask = Task.Run(() => { return GetRemoteVersionAsync(); });
                vtask.Wait();
                Version remoteVersion = vtask.Result;
                string Lver = $"{localVersion.Major}.{localVersion.Minor}.{localVersion.Build}";
                string Rver = $"{remoteVersion.Major}.{remoteVersion.Minor}.{remoteVersion.Build}";
                if (remoteVersion > localVersion)
                {
                    string msg = $"Version {Rver} is available. Update and restart?\\line\\line (You are running version {Lver})";
                    if (SimpleMessageBox.Show(this, msg,
                        "Update Available",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        UseWaitCursor = true;
                        SimpleMessageBox.ShowDialog(this, "Downloading and updating", "Updating");
                        Task<FileInfo?> ftask = Task.Run(() => { return GetRemoteFileAsync(); });
                        ftask.Wait();
                        if (ftask.Result != null)
                        {
                            string exeFullName = Application.ExecutablePath;
                            string? exeFolder = Path.GetDirectoryName(exeFullName);
                            if (!string.IsNullOrEmpty(exeFolder))
                            {
                                string oldName = exeFullName + ".old";
                                if (File.Exists(oldName))
                                    File.Delete(oldName);
                                File.Move(exeFullName, oldName); //can move a running exe file
                                ZipFile.ExtractToDirectory(ftask.Result.FullName, exeFolder);
                                File.Delete(ftask.Result.FullName); // remove temp file
                                Application.DoEvents();
                                Application.Restart();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SimpleMessageBox.Show(this, "Could not get version information.\\par " + ex.Message);
            }
        }

        private async Task<Version> GetRemoteVersionAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ProductInfoHeaderValue hdr = new ProductInfoHeaderValue(githubProject, "1");
                    client.DefaultRequestHeaders.UserAgent.Add(hdr);
                    HttpResponseMessage response = await client.GetAsync($"https://api.github.com/repos/{githubOwner}/{githubProject}/releases/latest");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Regex reVer = new Regex(@"""tag_name.:.v(\d+)\.(\d+)\.(\d+)(\.(\d+))?""");
                        Match match = reVer.Match(responseBody);
                        if (match.Success)
                        {
                            int major = Int32.Parse(match.Groups[1].Value);
                            int minor = Int32.Parse(match.Groups[2].Value);
                            int build = Int32.Parse(match.Groups[3].Value);
                            if (string.IsNullOrEmpty(match.Groups[5].Value))
                                return new Version(major, minor, build, 0);
                            else
                            {
                                int revision = Int32.Parse(match.Groups[5].Value);
                                return new Version(major, minor, build, revision);
                            }
                        }
                    }
                    return new Version(0, 0, 0, 0);
                }
            }
            catch { return new Version(0, 0, 0, 0); }
        }

        private async Task<FileInfo?> GetRemoteFileAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ProductInfoHeaderValue hdr = new ProductInfoHeaderValue(githubProject, "1");
                    client.DefaultRequestHeaders.UserAgent.Add(hdr);
                    string dl = $"https://github.com/{githubOwner}/{githubProject}/releases/latest/download/{githubProject}.zip";
                    HttpResponseMessage response = await client.GetAsync(dl);
                    if (response.IsSuccessStatusCode)
                    {
                        byte[] responseBody = await response.Content.ReadAsByteArrayAsync();
                        string tmp = Path.GetTempFileName();
                        File.WriteAllBytes(tmp, responseBody);
                        FileInfo fi = new FileInfo(tmp);
                        return fi;
                    }
                }
                return null;
            }
            catch { return null; }
        }

        #endregion

        #region Mapper

        private void buttonLogBrowse_Click(object sender, EventArgs e)
        {
            if (textBoxLogFile.Text.Length > 0)
            {
                string? path = Path.GetDirectoryName(textBoxLogFile.Text);
                if (path != null)
                {
                    openFileDialogTxt.InitialDirectory = path;
                }
            }
            if (openFileDialogTxt.ShowDialog(this) == DialogResult.OK)
            {
                textBoxLogFile.Text = openFileDialogTxt.FileName;
                textBoxLogFile.SelectionStart = textBoxLogFile.TextLength;
                textBoxLogFile.ScrollToCaret();
            }
        }

        private void buttonFindMapName_Click(object sender, EventArgs e)
        {
            string fileName = textBoxLogFile.Text;
            if (fileName.Length > 0 && File.Exists(fileName))
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string> mapNames = new List<string>();
                Match match;
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string? line = sr.ReadLine();
                            if (line != null)
                            {
                                match = Mapper2.reStyle.Match(line);
                                if (match.Success)
                                {
                                    string style = match.Groups["style"].Value;
                                    if (!mapNames.Contains(style))
                                        mapNames.Add(style);
                                }
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;

                contextMenuStripStyles.Items.Clear();
                foreach (string mapName in mapNames)
                {
                    ToolStripItem item = contextMenuStripStyles.Items.Add(mapName);
                    item.ToolTipText = "Click to set as Base map name";
                    item.Click += MapStyleItem_Click;
                }
                if (contextMenuStripStyles.Items.Count == 0)
                {
                    contextMenuStripStyles.Items.Add("None found");
                }
                Point loc = PointToScreen(textBoxMapName.Location);
                loc.Y += textBoxMapName.Height * 2;
                contextMenuStripStyles.Show(loc);
            }
        }

        private void MapStyleItem_Click(object? sender, EventArgs e)
        {
            ToolStripItem? item = sender as ToolStripItem;
            if (item != null)
            {
                textBoxMapName.Text = item.Text;
            }
        }

        private void buttonOutputFolder_Click(object sender, EventArgs e)
        {
            if (textBoxOutputFolder.Text.Length > 0)
            {
                string? path = Path.GetDirectoryName(textBoxOutputFolder.Text);
                if (path != null)
                {
                    folderBrowserDialog1.InitialDirectory = path;
                }
            }
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxOutputFolder.Text = folderBrowserDialog1.SelectedPath;
                textBoxOutputFolder.SelectionStart = textBoxOutputFolder.TextLength;
                textBoxOutputFolder.ScrollToCaret();
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (userChange)
            {
                if (dateTimePickerStart.Checked)
                    startUnixSeconds = (Int64)dateTimePickerStart.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                else
                    startUnixSeconds = -1;
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (userChange)
            {
                if (dateTimePickerEnd.Checked)
                    endUnixSeconds = (Int64)dateTimePickerEnd.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                else
                    endUnixSeconds = Int64.MaxValue;
            }
        }

        private void buttonScanDates_Click(object sender, EventArgs e)
        {
            string fileName = textBoxLogFile.Text;
            if (fileName.Length > 0 && File.Exists(fileName))
            {
                Cursor.Current = Cursors.WaitCursor;
                bool needStart = true;
                Int64 lineTime;
                Int64 fileStartTime = -1;
                Int64 fileEndTime = Int64.MaxValue;
                // non-exclusive file read
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string? line = sr.ReadLine();
                            if (line != null)
                            {
                                if (line.Length < 39) // EQII time stamp length
                                    continue;
                                if (!Int64.TryParse(line.Substring(1, 10), out lineTime))
                                    continue;
                                if (needStart)
                                {
                                    needStart = false;
                                    fileStartTime = lineTime;
                                }
                                fileEndTime = lineTime;
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;

                DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                userChange = false;
                if (fileStartTime > -1)
                {
                    bool wasChecked = dateTimePickerStart.Checked;
                    dateTimePickerStart.Value = baseDate.AddSeconds(fileStartTime).ToLocalTime();
                    dateTimePickerStart.Checked = wasChecked;
                    if (wasChecked)
                        startUnixSeconds = fileStartTime;
                }
                if (fileEndTime < Int64.MaxValue)
                {
                    bool wasChecked = dateTimePickerEnd.Checked;
                    dateTimePickerEnd.Value = baseDate.AddSeconds(fileEndTime).ToLocalTime();
                    dateTimePickerEnd.Checked = wasChecked;
                    if (wasChecked)
                        endUnixSeconds = fileEndTime;
                }
                userChange = true;
            }
        }

        private void buttonRunMapper_Click(object sender, EventArgs e)
        {
            userChange = false;
            toolStripStatusLabel1.Text = "Running...";
            string didLogFile = string.Empty;
            if (!radioButtonExistingMapper.Checked)
            {
                // use a task so the status line updates
                Task t = new Task(() => GenerateCleanLog());
                t.Start();
                t.Wait();
                didLogFile = "Log File -> ";
            }
            GenerateSvg();
            FixButtons();
            if (lineIndex.Count > 0)
            {
                mapperTabStatus = $"Ran: {didLogFile}Mapper file -> SVG and Index -> Zone Rect @ {DateTime.Now.ToShortTimeString()}";
                zonerectTabStatus = mapperTabStatus;
                toolStripStatusLabel1.Text = mapperTabStatus;
                indexTabStatus = "Double-click a row header to open Notepad++ at that line.";
            }
            else
            {
                mapperTabStatus = $"Ran: {didLogFile}Mapper file -> SVG -> Zone Rect @ {DateTime.Now.ToShortTimeString()}";
                zonerectTabStatus = mapperTabStatus;
                toolStripStatusLabel1.Text = mapperTabStatus;
                indexTabStatus = "Elevation sorting disables index.";
            }
            userChange = true;
        }

        private bool InputsOk(bool checkLog)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (checkLog)
            {
                if (string.IsNullOrEmpty(textBoxLogFile.Text))
                    sb.Append(@"Please choose an EQII log file.\par ");
            }
            if (string.IsNullOrEmpty(textBoxOutputFolder.Text))
                sb.AppendLine(@"Please choose an output folder.\par ");
            if (string.IsNullOrEmpty(textBoxMapName.Text) || textBoxMapName.ForeColor != Color.Black)
                sb.AppendLine(@"Please enter a map name.\par ");
            if (sb.Length > 0)
            {
                SimpleMessageBox.Show(this, sb.ToString());
                result = false;
            }
            return result;
        }

        private string BuildOutputName(string ext)
        {
            string mapName = textBoxMapName.Text;
            if (!string.IsNullOrEmpty(mapName))
            {
                if (!string.IsNullOrEmpty(textBoxMapLevel.Text))
                {
                    if (!mapName.EndsWith('_') && !textBoxMapLevel.Text.StartsWith('_'))
                        mapName += "_";
                    mapName += textBoxMapLevel.Text;
                }
                string outputFile = Path.Combine(textBoxOutputFolder.Text, mapName);
                return Path.ChangeExtension(outputFile, ext);
            }
            return string.Empty;
        }

        private void GenerateCleanLog()
        {
            if (InputsOk(true))
            {
                string inputFile = textBoxLogFile.Text;
                string outputFile = BuildOutputName("txt");
                Mapper2.GenerateCleanLog(inputFile, outputFile, radioButtonAppendMapper.Checked, startUnixSeconds, endUnixSeconds);
            }
        }

        private void GenerateSvg()
        {
            string inputFile = BuildOutputName("txt");
            string outputFile = BuildOutputName("svg");
            if (!File.Exists(inputFile))
            {
                SimpleMessageBox.Show(this, $"No such file: {inputFile}");
                return;
            }

            // using tasks so the UI updates
            // but we need them to finish before we continue
            mapper2 = new Mapper2();
            Task t1 = new Task(() => mapper2.GenerateSvg(inputFile, outputFile, textBoxElevations.Text));
            t1.Start();
            t1.Wait();

            Task t2 = new Task(() => GenerateIndex(inputFile));
            t2.Start();
            t2.Wait();

            lineIndexBindingSource.ResetBindings(false);

            if (checkBoxLaunchInkscape.Checked)
                LaunchProgram(textBoxInkscapeName.Text, outputFile);

            if (checkBoxLaunchDefault.Checked)
                LaunchProgram(textBoxDefaultSvgName.Text, outputFile);

            userChange = false;
            textBoxFileName.Text = outputFile;
            ScrollToEnd(textBoxFileName);
            ZoneRectFromSvg(outputFile);
            userChange = true;

        }

        private void LaunchProgram(string pgmName, string outputFile)
        {
            if (!string.IsNullOrEmpty(pgmName))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(pgmName);
                    startInfo.UseShellExecute = true;
                    startInfo.Arguments = outputFile;
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    string nobackslashes = ex.Message.Replace("\\", "/");
                    SimpleMessageBox.Show(this, nobackslashes);
                }
            }
        }

        private void textBoxMapName_TextChanged(object sender, EventArgs e)
        {
            string txtPath = BuildOutputName("txt");
            string txtFile = Path.GetFileName(txtPath);
            groupBoxMapper.Text = "Mapper File: " + txtFile;

            string svgPath = BuildOutputName("svg");
            string svgFile = Path.GetFileName(svgPath);
            groupBoxSvg.Text = "SVG File: " + svgFile;

            FixButtons();
            UpdateStatusLine();
        }

        private void textBoxFileInputs_TextChanged(object sender, EventArgs e)
        {
            FixButtons();
            UpdateStatusLine();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            FixButtons();
            UpdateStatusLine();
        }

        #endregion Mapper

        #region Zone Rect

        private void ZoneRectFromSvg(string path)
        {
            doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch (Exception dex)
            {
                string rtfok = dex.Message.Replace("\\", "\\\\");
                SimpleMessageBox.Show(this, "Invalid file format. " + rtfok);
                return;
            }

            XmlNode? node = doc.SelectSingleNode("//*[@id='NewLine1']");
            mapData.vertA = node?.Attributes?["d"]?.Value;
            node = doc.SelectSingleNode("//*[@id='NewLine2']");
            mapData.horzA = node?.Attributes?["d"]?.Value;
            node = doc.SelectSingleNode("//*[@id='NewLine3']");
            mapData.vertB = node?.Attributes?["d"]?.Value;
            node = doc.SelectSingleNode("//*[@id='NewLine4']");
            mapData.horzB = node?.Attributes?["d"]?.Value;

            XmlNodeList? nodes = doc.GetElementsByTagName("tspan");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode tnode in nodes)
                {
                    if (tnode.NextSibling != null && tnode.NextSibling.Value != null)
                    {
                        switch (tnode.InnerText)
                        {
                            case "UL:":     //inkscape
                            case "UL: ":    //mapper2
                                mapData.UL = tnode.NextSibling.Value;
                                break;
                            case "LR:":
                            case "LR: ":
                                mapData.LR = tnode.NextSibling.Value;
                                break;
                            case "Max Ele:":
                                mapData.MaxEl = tnode.NextSibling.Value.Replace("\n", "").Replace("\r", "").Trim();
                                textBoxMaxEl.Text = mapData.MaxEl.ToString();
                                break;
                            case "Min Ele:":
                                mapData.MinEl = tnode.NextSibling.Value.Replace("\n", "").Replace("\r", "").Trim();
                                textBoxMinEl.Text = mapData.MinEl.ToString();
                                break;
                        }
                    }
                }
                mapData.CalcCrosshairs();
                // scales are not bound, manually update them
                textBoxScaleWidth.Text = $"{mapData.inputScaleWidth:F0}";
                textBoxScaleHeight.Text = $"{mapData.inputScaleHeight:F0}";
                CalcRect();
                if (mapData.adjustedX)
                {
                    textBoxScaleWidth.BackColor = Color.LightGreen;
                    textBoxScaleHeight.BackColor = Color.White;
                }
                else if (mapData.adjustedY)
                {
                    textBoxScaleWidth.BackColor = Color.White;
                    textBoxScaleHeight.BackColor = Color.LightGreen;
                }
            }
        }

        private void buttonOpenSVG_Click(object sender, EventArgs e)
        {
            if (openFileDialogSvg.ShowDialog(this) == DialogResult.OK)
            {
                userChange = false;
                textBoxFileName.Text = openFileDialogSvg.FileName;
                ScrollToEnd(textBoxFileName);
                ZoneRectFromSvg(openFileDialogSvg.FileName);
                zonerectTabStatus = $"SVG file calculated @ {DateTime.Now.ToShortTimeString()}";
                toolStripStatusLabel1.Text = zonerectTabStatus;
                userChange = true;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            CalcRect();
            zonerectTabStatus = $"Zone Rect calculated @ {DateTime.Now.ToShortTimeString()}";
            toolStripStatusLabel1.Text = zonerectTabStatus;
        }

        private void CalcRect()
        {
            mapData.CalcRect();
        }

        private void buttonCopyZoneRect_Click(object sender, EventArgs e)
        {
        }

        private void menuButtonCopyZonerect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mapData.zonerect))
                SimpleMessageBox.Show(this, "Calculate a zonerect first.");
            else
            {
                try
                {
                    string copy = mapData.zonerect;
                    if (includeElevationsToolStripMenuItem.Checked)
                    {
                        if (!string.IsNullOrEmpty(textBoxMinEl.Text))
                            copy += $" heightmin=\"{textBoxMinEl.Text}\"";
                        if (!string.IsNullOrEmpty(textBoxMaxEl.Text))
                            copy += $" heightmax=\"{textBoxMaxEl.Text}\"";
                    }
                    Clipboard.SetText(copy);
                }
                catch (Exception)
                {
                    SimpleMessageBox.Show(this, "Clipboard copy failed. Please try again.");
                }
            }
        }

        private void contextMenuStripElev_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxMinEl.Text)
                && !string.IsNullOrEmpty(textBoxMaxEl.Text))
            {
                includeElevationsToolStripMenuItem.Enabled = true;
            }
            else
                includeElevationsToolStripMenuItem.Enabled = false;
        }

        private void includeElevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (includeElevationsToolStripMenuItem.Checked)
            {
                includeElevationsToolStripMenuItem.Checked = false;
            }
            else
            {
                includeElevationsToolStripMenuItem.Checked = true;
            }
        }

        private void ScrollToEnd(TextBox tb)
        {
            tb.SelectionStart = tb.TextLength;
            tb.ScrollToCaret();
        }

        private void checkBoxCustomMapSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCustomMapSize.Checked)
            {
                textBoxImageWidth.ReadOnly = false;
                textBoxImageHeight.ReadOnly = false;
                textBoxImageWidth.Focus();
            }
            else
            {
                textBoxImageWidth.ReadOnly = true;
                textBoxImageWidth.Text = DefaultMapWidth.ToString();
                textBoxImageHeight.ReadOnly = true;
                textBoxImageHeight.Text = DefaultMapHeight.ToString();
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox? tb = sender as TextBox;
            if (tb != null)
                tb.SelectAll();
        }

        private void textBoxGrey_Enter(object sender, EventArgs e)
        {
            TextBox? tb = sender as TextBox;
            if (tb != null && tb.ForeColor != Color.Black)
            {
                tb.Text = String.Empty;
                tb.ForeColor = Color.Black;
            }
        }

        private void textBoxZRInput_TextChanged(object sender, EventArgs e)
        {
            // When the inputs are set via the Mapper tab,
            // we want to leave the status line indicating the mapper [Run] status.
            // But if the user manually modifies an input, we want to show a
            // status of "Ready", to indicate that the zonerect needs an update.
            TextBox? tb = sender as TextBox;
            if (tb != null)
            {
                if (tb.Visible)
                {
                    if (tb.Tag == null)
                        tb.Tag = true;
                    else if ((bool)tb.Tag == false)
                        tb.Tag = true;
                    else
                        toolStripStatusLabel1.Text = "Ready";
                }
                else
                    tb.Tag = false;
            }
        }

        private void textBoxScaleWidth_Validated(object sender, EventArgs e)
        {
            if (userChange)
            {
                toolStripStatusLabel1.Text = "Ready";

                textBoxScaleWidth.BackColor = Color.White;
                textBoxScaleHeight.BackColor = Color.White;
                // these are not data bound b/c they are interdependent, so do updates manually
                bool ok = double.TryParse(textBoxScaleWidth.Text, out mapData.inputScaleWidth);
                ok &= double.TryParse(textBoxScaleHeight.Text, out mapData.inputScaleHeight);
                if (ok)
                {
                    mapData.FixAspectForNewX();
                    textBoxScaleHeight.Text = $"{mapData.inputScaleHeight:N0}";
                    toolStripStatusLabel1.Text = $"Zone Rect calculated @ {DateTime.Now.ToShortTimeString()}";

                }
            }
        }

        private void textBoxScaleHeight_Validated(object sender, EventArgs e)
        {
            if (userChange)
            {
                toolStripStatusLabel1.Text = "Ready";

                textBoxScaleWidth.BackColor = Color.White;
                textBoxScaleHeight.BackColor = Color.White;
                bool ok = double.TryParse(textBoxScaleWidth.Text, out mapData.inputScaleWidth);
                ok &= double.TryParse(textBoxScaleHeight.Text, out mapData.inputScaleHeight);
                if (ok)
                {
                    mapData.FixAspectForNewY();
                    textBoxScaleWidth.Text = $"{mapData.inputScaleWidth:N0}";
                    toolStripStatusLabel1.Text = $"Zone Rect calculated @ {DateTime.Now.ToShortTimeString()}";
                }
            }

        }

        #endregion Zone Rect

        #region Map Loc

        private void buttonPasteLoc_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = false;
                string clip = Clipboard.GetText(TextDataFormat.Text).Trim();
                if (!string.IsNullOrEmpty(clip))
                {
                    string[] loc = clip.Split(' ');
                    if (loc.Length == 6)
                    {
                        ok = true;
                        textBoxMapLocX.Text = loc[0].Trim();
                        textBoxMapLocY.Text = loc[2].Trim();
                    }
                }
                if (!ok)
                    SimpleMessageBox.Show(this, "Clipboard content is not a /loc clipboard");
            }
            catch (Exception cex)
            {
                SimpleMessageBox.Show(this, "Clipboard content fetch failed: " + cex.Message);
            }
        }

        private void buttonPasteZoneRect_Click(object sender, EventArgs e)
        {
            textBoxMapLocZoneRect.Text = mapData.zonerect;
        }

        private void buttonPasteMapSize_Click(object sender, EventArgs e)
        {
            textBoxMapLocWidth.Text = $"{mapData.imageWidth:F0}";
            textBoxMapLocHeight.Text = $"{mapData.imageHeight:F0}";
            if (mapData.imageWidth != DefaultMapWidth
                || mapData.imageHeight != DefaultMapHeight)
            {
                checkBoxCustomMapLocMapSize.Checked = true;
            }
            else
                checkBoxCustomMapLocMapSize.Checked = false;
        }

        private void checkBoxCustomMapLocMapSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCustomMapLocMapSize.Checked)
            {
                textBoxMapLocWidth.ReadOnly = false;
                textBoxMapLocHeight.ReadOnly = false;
                textBoxMapLocWidth.Focus();
            }
            else
            {
                textBoxMapLocWidth.ReadOnly = true;
                textBoxMapLocWidth.Text = DefaultMapWidth.ToString();
                textBoxMapLocHeight.ReadOnly = true;
                textBoxMapLocHeight.Text = DefaultMapHeight.ToString();
            }

        }

        private void buttonMapLocCalc_Click(object sender, EventArgs e)
        {
            maplocTabStatus = "Please provide necessary inputs.";
            Match match = reZoneRect.Match(textBoxMapLocZoneRect.Text);
            if (match.Success && match.Groups.Count == 5)
            {
                double ulx;
                if (!double.TryParse(match.Groups["ulx"].Value, out ulx))
                {
                    SimpleMessageBox.Show(this, "Zone rect X1 is invalid.");
                    return;
                }
                double uly;
                if (!double.TryParse(match.Groups["uly"].Value, out uly))
                {
                    SimpleMessageBox.Show(this, "Zone rect Y1 is invalid.");
                    return;
                }
                double lrx;
                if (!double.TryParse(match.Groups["lrx"].Value, out lrx))
                {
                    SimpleMessageBox.Show(this, "Zone rect X2 is invalid.");
                    return;
                }
                double lry;
                if (!double.TryParse(match.Groups["lry"].Value, out lry))
                {
                    SimpleMessageBox.Show(this, "Zone rect Y2 is invalid.");
                    return;
                }

                double locx;
                if (!double.TryParse(textBoxMapLocX.Text.Trim(), out locx))
                {
                    SimpleMessageBox.Show(this, "In game /loc coordinate X is invalid.");
                    return;
                }
                double locy;
                if (!double.TryParse(textBoxMapLocY.Text.Trim(), out locy))
                {
                    SimpleMessageBox.Show(this, "In game /loc coordinate Y is invalid.");
                    return;
                }
                double imWidth;
                if (!double.TryParse(textBoxMapLocWidth.Text.Trim(), out imWidth))
                {
                    SimpleMessageBox.Show(this, "Image width is invalid.");
                    return;
                }
                double imHeight;
                if (!double.TryParse(textBoxMapLocHeight.Text.Trim(), out imHeight))
                {
                    SimpleMessageBox.Show(this, "Image height is invalid.");
                    return;
                }

                double zoneRectWidth = lrx - ulx;
                double zoneRectHeight = lry - uly;
                double mapX = (((locx * -1) - ulx) / zoneRectWidth) * imWidth;
                double mapY = ((locy - uly) / zoneRectHeight) * imHeight;
                textBoxMapLocation.Text = $"{mapX:F0},{mapY:F0}";
                maplocTabStatus = $"Map Loc calculated at {DateTime.Now.ToShortTimeString()}";
                toolStripStatusLabel1.Text = maplocTabStatus;
            }
        }

        private void OpenMapStyles(string fileName)
        {
            mapStyles.Clear();
            if (!string.IsNullOrEmpty(fileName))
            {
                doc = new XmlDocument();
                try
                {
                    // the mapstyles files do not have a root element
                    // but it's required by XmlDocument
                    // so add one
                    string fragment = File.ReadAllText(fileName);
                    int firstBracket = fragment.IndexOf('>');
                    if (firstBracket != -1)
                    {
                        string xml = fragment.Insert(firstBracket + 1, "<root>") + "</root>";
                        doc.LoadXml(xml);
                    }
                    else
                    {
                        SimpleMessageBox.Show(this, "Invalid xml file format");
                        return;
                    }
                }
                catch (Exception dex)
                {
                    string rtfok = dex.Message.Replace("\\", "\\\\");
                    SimpleMessageBox.Show(this, "Invalid xml file format. " + rtfok);
                    return;
                }

                // collect the file items
                XmlNodeList? nodes = doc.GetElementsByTagName("ImageStyle");
                if (nodes != null)
                {
                    string longestName = string.Empty;
                    foreach (XmlNode node in nodes)
                    {
                        string? name = node.Attributes?["displayname"]?.Value;
                        string? zonerect = node.Attributes?["zonerect"]?.Value;
                        string? sourcerect = node.ChildNodes[0]?.Attributes?["SourceRect"]?.Value;
                        if (name != null && zonerect != null && sourcerect != null)
                        {
                            StyleZoneRect szr = new StyleZoneRect { DisplayName = name, ZoneRect = zonerect, SourceRect = sourcerect };
                            mapStyles.Add(szr);
                            if (szr.DisplayName.Length > longestName.Length)
                                longestName = szr.DisplayName;
                        }
                    }
                    mapStyles.Sort();

                    // add an empty item at the top
                    mapStyles.Insert(0, new StyleZoneRect { DisplayName = String.Empty, ZoneRect = String.Empty });

                    // update the combo box
                    mapStylesBindingSource.ResetBindings(false);

                    int width = TextRenderer.MeasureText(longestName, comboBoxMapStyles.Font).Width + SystemInformation.VerticalScrollBarWidth;
                    if (comboBoxMapStyles.DropDownWidth < width)
                        comboBoxMapStyles.DropDownWidth = width;
                }
            }
        }

        private void buttonOpenMapStyle_Click(object sender, EventArgs e)
        {
            string? UiDir = Path.GetDirectoryName(Properties.Settings.Default.MapStyleFile);
            if (UiDir != null)
                openFileDialogXml.InitialDirectory = UiDir;
            if (openFileDialogXml.ShowDialog() == DialogResult.OK)
            {
                OpenMapStyles(openFileDialogXml.FileName);
            }
        }

        private void comboBoxMapStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxMapStyles.SelectedIndex;
            if (index >= 0 && mapStyles.Count > index)
            {
                textBoxMapLocZoneRect.Text = mapStyles[index].ZoneRect;
                string? sourceRect = mapStyles[index].SourceRect;
                if (sourceRect != null)
                {
                    Match match = reZoneRect.Match(sourceRect);
                    if (match.Success)
                    {
                        string lrx = match.Groups["lrx"].Value;
                        string lry = match.Groups["lry"].Value;
                        if (textBoxMapLocWidth.Text != lrx)
                            textBoxMapLocWidth.Text = lrx;
                        if (textBoxMapLocHeight.Text != lry)
                            textBoxMapLocHeight.Text = lry;
                        if (lrx != DefaultMapWidth.ToString() || lry != DefaultMapHeight.ToString())
                            checkBoxCustomMapLocMapSize.Checked = true;
                        else
                            checkBoxCustomMapLocMapSize.Checked = false;
                    }
                }
            }
        }

        private void textBoxMapLoc_TextChanged(object sender, EventArgs e)
        {
            FixButtons();
            UpdateStatusLine();
        }

        #endregion Map Loc

        #region Line Index

        private void GenerateIndex(string inputFile)
        {
            lineIndex.Clear();
            lineIndex.fileName = inputFile;

            // can't do an index if the mapper rearranges lines for elevation groups
            // (mapper would need rework to support re-ordered lines)
            if (!string.IsNullOrEmpty(textBoxElevations.Text)) return;

            using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long lineNumber = 0;
                long idNumber = 5;      // first 4 ids are the crosshairs, which are not in the .txt file
                int locations = 0;
                bool sawStart = false;
                long startLineNum = 0;
                Match match;
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        if (line != null)
                        {
                            lineNumber++;
                            if (line.Contains("\\/a start new map line"))
                            {
                                // need a location before we have a line
                                locations = 0;
                                sawStart = true;
                                startLineNum = lineNumber;
                            }
                            else if ((match = Mapper2.reLoc.Match(line)).Success)
                            {
                                locations++;
                                if (locations > 0 && sawStart)
                                {
                                    lineIndex.Add(new SvgLine { svgId = $"NewLine{idNumber}", lineNumber = startLineNum });
                                    idNumber++;
                                    sawStart = false;
                                }
                            }
                        }
                    }
                }
            }
            Debug.WriteLine("index done");
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells["lineNumberDataGridViewTextBoxColumn"];
            string? lineNum = cell.Value.ToString();
            if (lineNum != null)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo("Notepad++");
                    startInfo.UseShellExecute = true;
                    startInfo.Arguments = $"-n{lineNum} {lineIndex.fileName}";
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    string nobackslashes = ex.Message.Replace("\\", "/");
                    SimpleMessageBox.Show(this, "Could not launch Notepad++: " + nobackslashes);
                }
            }
        }


        #endregion Line Index

        #region Help

        private void richTextBox2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                if (e.LinkText != null)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(e.LinkText);
                    startInfo.UseShellExecute = true;
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                string nobackslashes = ex.Message.Replace("\\", "/");
                SimpleMessageBox.Show(this, "Link failed: " + nobackslashes);
            }
        }

        #endregion Help
    }
}