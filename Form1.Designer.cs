namespace EQ2MapTools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPageMapper = new TabPage();
            buttonScanDates = new Button();
            label36 = new Label();
            label35 = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            buttonFindMapName = new Button();
            groupBoxSvg = new GroupBox();
            textBoxDefaultSvgName = new TextBox();
            textBoxInkscapeName = new TextBox();
            checkBoxLaunchInkscape = new CheckBox();
            checkBoxLaunchDefault = new CheckBox();
            label24 = new Label();
            textBoxElevations = new TextBox();
            buttonRunMapper = new Button();
            textBoxMapLevel = new TextBox();
            label23 = new Label();
            textBoxMapName = new TextBox();
            label20 = new Label();
            buttonOutputFolder = new Button();
            textBoxOutputFolder = new TextBox();
            label19 = new Label();
            buttonLogBrowse = new Button();
            textBoxLogFile = new TextBox();
            label18 = new Label();
            groupBoxMapper = new GroupBox();
            radioButtonBuildMapper = new RadioButton();
            radioButtonAppendMapper = new RadioButton();
            radioButtonExistingMapper = new RadioButton();
            tabPageZoneRect = new TabPage();
            menuButtonCopyZonerect = new MenuButton();
            contextMenuStripElev = new ContextMenuStrip(components);
            includeElevationsToolStripMenuItem = new ToolStripMenuItem();
            label22 = new Label();
            label16 = new Label();
            textBoxFileName = new TextBox();
            label17 = new Label();
            buttonCalculate = new Button();
            buttonOpenSVG = new Button();
            textBoxZoneRect = new TextBox();
            mapDataBindingSource = new BindingSource(components);
            label15 = new Label();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            textBoxScaleHeight = new TextBox();
            textBoxScaleWidth = new TextBox();
            label11 = new Label();
            checkBoxCustomMapSize = new CheckBox();
            label10 = new Label();
            label9 = new Label();
            textBoxImageHeight = new TextBox();
            textBoxImageWidth = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            textBoxMapBY = new TextBox();
            label5 = new Label();
            textBoxMapAY = new TextBox();
            textBoxMapBX = new TextBox();
            label6 = new Label();
            textBoxMapAX = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label21 = new Label();
            textBoxGameBY = new TextBox();
            label7 = new Label();
            textBoxMaxEl = new TextBox();
            label4 = new Label();
            textBoxGameAY = new TextBox();
            textBoxMinEl = new TextBox();
            textBoxGameBX = new TextBox();
            label3 = new Label();
            textBoxGameAX = new TextBox();
            tabPageMapLoc = new TabPage();
            label34 = new Label();
            checkBoxLoadMapstyles = new CheckBox();
            buttonOpenMapStyle = new Button();
            label33 = new Label();
            comboBoxMapStyles = new ComboBox();
            buttonMapLocCalc = new Button();
            textBoxMapLocation = new TextBox();
            label32 = new Label();
            label29 = new Label();
            buttonPasteMapSize = new Button();
            checkBoxCustomMapLocMapSize = new CheckBox();
            label26 = new Label();
            label27 = new Label();
            textBoxMapLocHeight = new TextBox();
            textBoxMapLocWidth = new TextBox();
            label28 = new Label();
            buttonPasteZoneRect = new Button();
            textBoxMapLocZoneRect = new TextBox();
            label25 = new Label();
            groupBox3 = new GroupBox();
            buttonPasteLoc = new Button();
            label30 = new Label();
            textBoxMapLocY = new TextBox();
            label31 = new Label();
            textBoxMapLocX = new TextBox();
            tabPageLines = new TabPage();
            dataGridView1 = new DataGridView();
            svgIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lineNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lineIndexBindingSource = new BindingSource(components);
            tabPageHelp = new TabPage();
            richTextBox2 = new RichTextBox();
            contextMenuStripStyles = new ContextMenuStrip(components);
            mapStylesBindingSource = new BindingSource(components);
            openFileDialogSvg = new OpenFileDialog();
            toolTip1 = new ToolTip(components);
            openFileDialogTxt = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            openFileDialogXml = new OpenFileDialog();
            tabControl1.SuspendLayout();
            tabPageMapper.SuspendLayout();
            groupBoxSvg.SuspendLayout();
            groupBoxMapper.SuspendLayout();
            tabPageZoneRect.SuspendLayout();
            contextMenuStripElev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapDataBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageMapLoc.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPageLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lineIndexBindingSource).BeginInit();
            tabPageHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapStylesBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageMapper);
            tabControl1.Controls.Add(tabPageZoneRect);
            tabControl1.Controls.Add(tabPageMapLoc);
            tabControl1.Controls.Add(tabPageLines);
            tabControl1.Controls.Add(tabPageHelp);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(476, 495);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageMapper
            // 
            tabPageMapper.BackColor = SystemColors.Control;
            tabPageMapper.Controls.Add(buttonScanDates);
            tabPageMapper.Controls.Add(label36);
            tabPageMapper.Controls.Add(label35);
            tabPageMapper.Controls.Add(dateTimePickerEnd);
            tabPageMapper.Controls.Add(dateTimePickerStart);
            tabPageMapper.Controls.Add(buttonFindMapName);
            tabPageMapper.Controls.Add(groupBoxSvg);
            tabPageMapper.Controls.Add(label24);
            tabPageMapper.Controls.Add(textBoxElevations);
            tabPageMapper.Controls.Add(buttonRunMapper);
            tabPageMapper.Controls.Add(textBoxMapLevel);
            tabPageMapper.Controls.Add(label23);
            tabPageMapper.Controls.Add(textBoxMapName);
            tabPageMapper.Controls.Add(label20);
            tabPageMapper.Controls.Add(buttonOutputFolder);
            tabPageMapper.Controls.Add(textBoxOutputFolder);
            tabPageMapper.Controls.Add(label19);
            tabPageMapper.Controls.Add(buttonLogBrowse);
            tabPageMapper.Controls.Add(textBoxLogFile);
            tabPageMapper.Controls.Add(label18);
            tabPageMapper.Controls.Add(groupBoxMapper);
            tabPageMapper.Location = new Point(4, 24);
            tabPageMapper.Name = "tabPageMapper";
            tabPageMapper.Padding = new Padding(3);
            tabPageMapper.Size = new Size(468, 467);
            tabPageMapper.TabIndex = 3;
            tabPageMapper.Text = "Mapper2";
            // 
            // buttonScanDates
            // 
            buttonScanDates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonScanDates.Image = (Image)resources.GetObject("buttonScanDates.Image");
            buttonScanDates.Location = new Point(435, 208);
            buttonScanDates.Name = "buttonScanDates";
            buttonScanDates.Size = new Size(26, 25);
            buttonScanDates.TabIndex = 17;
            toolTip1.SetToolTip(buttonScanDates, "Scan the Input Log File for its start and end times");
            buttonScanDates.UseVisualStyleBackColor = true;
            buttonScanDates.Click += buttonScanDates_Click;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(228, 192);
            label36.Name = "label36";
            label36.Size = new Size(111, 15);
            label36.TabIndex = 15;
            label36.Text = "Log Filter End Time:";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(11, 192);
            label35.Name = "label35";
            label35.Size = new Size(115, 15);
            label35.TabIndex = 13;
            label35.Text = "Log Filter Start Time:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerEnd.Checked = false;
            dateTimePickerEnd.CustomFormat = "ddMMMyy HH:mm:ss";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(228, 210);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShowCheckBox = true;
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 16;
            toolTip1.SetToolTip(dateTimePickerEnd, "Stop extracting lines newer than this (military) time.");
            dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerStart.Checked = false;
            dateTimePickerStart.CustomFormat = "ddMMMyy HH:mm:ss";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(11, 210);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShowCheckBox = true;
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 14;
            toolTip1.SetToolTip(dateTimePickerStart, "Extract log file lines starting at this (military) time.");
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // buttonFindMapName
            // 
            buttonFindMapName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFindMapName.Image = (Image)resources.GetObject("buttonFindMapName.Image");
            buttonFindMapName.Location = new Point(435, 117);
            buttonFindMapName.Name = "buttonFindMapName";
            buttonFindMapName.Size = new Size(26, 25);
            buttonFindMapName.TabIndex = 8;
            toolTip1.SetToolTip(buttonFindMapName, "Find map style names in the Input Log File");
            buttonFindMapName.UseVisualStyleBackColor = true;
            buttonFindMapName.Click += buttonFindMapName_Click;
            // 
            // groupBoxSvg
            // 
            groupBoxSvg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSvg.Controls.Add(textBoxDefaultSvgName);
            groupBoxSvg.Controls.Add(textBoxInkscapeName);
            groupBoxSvg.Controls.Add(checkBoxLaunchInkscape);
            groupBoxSvg.Controls.Add(checkBoxLaunchDefault);
            groupBoxSvg.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxSvg.Location = new Point(11, 352);
            groupBoxSvg.Name = "groupBoxSvg";
            groupBoxSvg.Size = new Size(417, 78);
            groupBoxSvg.TabIndex = 19;
            groupBoxSvg.TabStop = false;
            groupBoxSvg.Text = "SVG file";
            toolTip1.SetToolTip(groupBoxSvg, "Vector file representing the map.");
            // 
            // textBoxDefaultSvgName
            // 
            textBoxDefaultSvgName.Font = new Font("Segoe UI", 9F);
            textBoxDefaultSvgName.Location = new Point(159, 47);
            textBoxDefaultSvgName.Name = "textBoxDefaultSvgName";
            textBoxDefaultSvgName.Size = new Size(141, 23);
            textBoxDefaultSvgName.TabIndex = 3;
            // 
            // textBoxInkscapeName
            // 
            textBoxInkscapeName.Font = new Font("Segoe UI", 9F);
            textBoxInkscapeName.Location = new Point(159, 20);
            textBoxInkscapeName.Name = "textBoxInkscapeName";
            textBoxInkscapeName.Size = new Size(141, 23);
            textBoxInkscapeName.TabIndex = 1;
            textBoxInkscapeName.Text = "Inkscape.exe";
            // 
            // checkBoxLaunchInkscape
            // 
            checkBoxLaunchInkscape.AutoSize = true;
            checkBoxLaunchInkscape.Font = new Font("Segoe UI", 9F);
            checkBoxLaunchInkscape.Location = new Point(6, 24);
            checkBoxLaunchInkscape.Name = "checkBoxLaunchInkscape";
            checkBoxLaunchInkscape.Size = new Size(147, 19);
            checkBoxLaunchInkscape.TabIndex = 0;
            checkBoxLaunchInkscape.Text = "Launch editor / viewer:";
            toolTip1.SetToolTip(checkBoxLaunchInkscape, "Open the SVG in the spcified editor / viewer.\r\nInkscape is good for editing the file.");
            checkBoxLaunchInkscape.UseVisualStyleBackColor = true;
            // 
            // checkBoxLaunchDefault
            // 
            checkBoxLaunchDefault.AutoSize = true;
            checkBoxLaunchDefault.Checked = true;
            checkBoxLaunchDefault.CheckState = CheckState.Checked;
            checkBoxLaunchDefault.Font = new Font("Segoe UI", 9F);
            checkBoxLaunchDefault.Location = new Point(6, 51);
            checkBoxLaunchDefault.Name = "checkBoxLaunchDefault";
            checkBoxLaunchDefault.Size = new Size(147, 19);
            checkBoxLaunchDefault.TabIndex = 2;
            checkBoxLaunchDefault.Text = "Launch editor / viewer:";
            toolTip1.SetToolTip(checkBoxLaunchDefault, "Open the SVG file in the specified editor / viewer.\r\nA browser is good for a quick view while collecting /loc data.\r\nDefaults to the default program for SVG files set in Windows.");
            checkBoxLaunchDefault.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(228, 146);
            label24.Name = "label24";
            label24.Size = new Size(115, 15);
            label24.TabIndex = 11;
            label24.Text = "Group by elevations:";
            toolTip1.SetToolTip(label24, resources.GetString("label24.ToolTip"));
            // 
            // textBoxElevations
            // 
            textBoxElevations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxElevations.ForeColor = SystemColors.ControlText;
            textBoxElevations.Location = new Point(228, 164);
            textBoxElevations.Name = "textBoxElevations";
            textBoxElevations.Size = new Size(200, 23);
            textBoxElevations.TabIndex = 12;
            toolTip1.SetToolTip(textBoxElevations, resources.GetString("textBoxElevations.ToolTip"));
            // 
            // buttonRunMapper
            // 
            buttonRunMapper.Anchor = AnchorStyles.Bottom;
            buttonRunMapper.Location = new Point(177, 435);
            buttonRunMapper.Name = "buttonRunMapper";
            buttonRunMapper.Size = new Size(114, 25);
            buttonRunMapper.TabIndex = 20;
            buttonRunMapper.Text = "Run";
            toolTip1.SetToolTip(buttonRunMapper, "Build specified files.");
            buttonRunMapper.UseVisualStyleBackColor = true;
            buttonRunMapper.Click += buttonRunMapper_Click;
            // 
            // textBoxMapLevel
            // 
            textBoxMapLevel.Location = new Point(11, 164);
            textBoxMapLevel.Name = "textBoxMapLevel";
            textBoxMapLevel.Size = new Size(200, 23);
            textBoxMapLevel.TabIndex = 10;
            toolTip1.SetToolTip(textBoxMapLevel, "This field is appended to the Base Map Name\r\nto create the final file name. It can be blank.\r\n");
            textBoxMapLevel.TextChanged += textBoxMapName_TextChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(11, 146);
            label23.Name = "label23";
            label23.Size = new Size(64, 15);
            label23.TabIndex = 9;
            label23.Text = "Map Level:";
            toolTip1.SetToolTip(label23, "This field is appended to the Base Map Name\r\nto create the final file name. It can be blank.");
            // 
            // textBoxMapName
            // 
            textBoxMapName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMapName.ForeColor = Color.Silver;
            textBoxMapName.Location = new Point(11, 118);
            textBoxMapName.Name = "textBoxMapName";
            textBoxMapName.Size = new Size(417, 23);
            textBoxMapName.TabIndex = 7;
            textBoxMapName.Text = "e.g. map_expXX_zone";
            toolTip1.SetToolTip(textBoxMapName, "Base file name for the .txt and .svg files.\r\n");
            textBoxMapName.TextChanged += textBoxMapName_TextChanged;
            textBoxMapName.Enter += textBoxGrey_Enter;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(11, 100);
            label20.Name = "label20";
            label20.Size = new Size(94, 15);
            label20.TabIndex = 6;
            label20.Text = "Base map name:";
            toolTip1.SetToolTip(label20, "Base file name for the .txt and .svg files.");
            // 
            // buttonOutputFolder
            // 
            buttonOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOutputFolder.AutoSize = true;
            buttonOutputFolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOutputFolder.Location = new Point(435, 71);
            buttonOutputFolder.Name = "buttonOutputFolder";
            buttonOutputFolder.Size = new Size(26, 25);
            buttonOutputFolder.TabIndex = 5;
            buttonOutputFolder.Text = "...";
            toolTip1.SetToolTip(buttonOutputFolder, "Browse for ouput files folder");
            buttonOutputFolder.UseVisualStyleBackColor = true;
            buttonOutputFolder.Click += buttonOutputFolder_Click;
            // 
            // textBoxOutputFolder
            // 
            textBoxOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxOutputFolder.Location = new Point(11, 72);
            textBoxOutputFolder.Name = "textBoxOutputFolder";
            textBoxOutputFolder.Size = new Size(417, 23);
            textBoxOutputFolder.TabIndex = 4;
            toolTip1.SetToolTip(textBoxOutputFolder, "Destination folder for the .txt and .svg files.");
            textBoxOutputFolder.TextChanged += textBoxFileInputs_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(8, 54);
            label19.Name = "label19";
            label19.Size = new Size(84, 15);
            label19.TabIndex = 3;
            label19.Text = "Output Folder:";
            toolTip1.SetToolTip(label19, "Destination folder for the .txt and .svg files.");
            // 
            // buttonLogBrowse
            // 
            buttonLogBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLogBrowse.AutoSize = true;
            buttonLogBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLogBrowse.Location = new Point(435, 24);
            buttonLogBrowse.Name = "buttonLogBrowse";
            buttonLogBrowse.Size = new Size(26, 25);
            buttonLogBrowse.TabIndex = 2;
            buttonLogBrowse.Text = "...";
            toolTip1.SetToolTip(buttonLogBrowse, "Browse for game log file to process");
            buttonLogBrowse.UseVisualStyleBackColor = true;
            buttonLogBrowse.Click += buttonLogBrowse_Click;
            // 
            // textBoxLogFile
            // 
            textBoxLogFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLogFile.Location = new Point(11, 26);
            textBoxLogFile.Name = "textBoxLogFile";
            textBoxLogFile.Size = new Size(417, 23);
            textBoxLogFile.TabIndex = 1;
            toolTip1.SetToolTip(textBoxLogFile, "EQII generated log file containing the map making emotes.\r\n");
            textBoxLogFile.TextChanged += textBoxFileInputs_TextChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(11, 8);
            label18.Name = "label18";
            label18.Size = new Size(82, 15);
            label18.TabIndex = 0;
            label18.Text = "Input Log File:";
            toolTip1.SetToolTip(label18, "EQII generated log file containing the map making emotes.");
            // 
            // groupBoxMapper
            // 
            groupBoxMapper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMapper.Controls.Add(radioButtonBuildMapper);
            groupBoxMapper.Controls.Add(radioButtonAppendMapper);
            groupBoxMapper.Controls.Add(radioButtonExistingMapper);
            groupBoxMapper.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxMapper.Location = new Point(11, 245);
            groupBoxMapper.Name = "groupBoxMapper";
            groupBoxMapper.Size = new Size(417, 98);
            groupBoxMapper.TabIndex = 18;
            groupBoxMapper.TabStop = false;
            groupBoxMapper.Text = "Mapper file";
            toolTip1.SetToolTip(groupBoxMapper, "File containing just the log lines pertaining to making a map.");
            // 
            // radioButtonBuildMapper
            // 
            radioButtonBuildMapper.AutoSize = true;
            radioButtonBuildMapper.Checked = true;
            radioButtonBuildMapper.Font = new Font("Segoe UI", 9F);
            radioButtonBuildMapper.Location = new Point(6, 22);
            radioButtonBuildMapper.Name = "radioButtonBuildMapper";
            radioButtonBuildMapper.Size = new Size(244, 19);
            radioButtonBuildMapper.TabIndex = 0;
            radioButtonBuildMapper.TabStop = true;
            radioButtonBuildMapper.Text = "Build new mapper file from Input Log File";
            toolTip1.SetToolTip(radioButtonBuildMapper, "Extract relevent lines from the Input Log File into a new mapper file.");
            radioButtonBuildMapper.UseVisualStyleBackColor = true;
            radioButtonBuildMapper.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonAppendMapper
            // 
            radioButtonAppendMapper.AutoSize = true;
            radioButtonAppendMapper.Font = new Font("Segoe UI", 9F);
            radioButtonAppendMapper.Location = new Point(6, 47);
            radioButtonAppendMapper.Name = "radioButtonAppendMapper";
            radioButtonAppendMapper.Size = new Size(341, 19);
            radioButtonAppendMapper.TabIndex = 1;
            radioButtonAppendMapper.Text = "Append Input Log File mapping lines to existing mapper file";
            toolTip1.SetToolTip(radioButtonAppendMapper, "Useful if adding lines to an exsting map from a new Input Log File");
            radioButtonAppendMapper.UseVisualStyleBackColor = true;
            radioButtonAppendMapper.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonExistingMapper
            // 
            radioButtonExistingMapper.AutoSize = true;
            radioButtonExistingMapper.Font = new Font("Segoe UI", 9F);
            radioButtonExistingMapper.Location = new Point(6, 72);
            radioButtonExistingMapper.Name = "radioButtonExistingMapper";
            radioButtonExistingMapper.Size = new Size(319, 19);
            radioButtonExistingMapper.TabIndex = 2;
            radioButtonExistingMapper.Text = "Use existing mapper file as is (Input Log File is not used)";
            toolTip1.SetToolTip(radioButtonExistingMapper, "Useful if you have edited the mapper file by hand and want to keep the changes.");
            radioButtonExistingMapper.UseVisualStyleBackColor = true;
            radioButtonExistingMapper.CheckedChanged += radioButton_CheckedChanged;
            // 
            // tabPageZoneRect
            // 
            tabPageZoneRect.BackColor = SystemColors.Control;
            tabPageZoneRect.Controls.Add(menuButtonCopyZonerect);
            tabPageZoneRect.Controls.Add(label22);
            tabPageZoneRect.Controls.Add(label16);
            tabPageZoneRect.Controls.Add(textBoxFileName);
            tabPageZoneRect.Controls.Add(label17);
            tabPageZoneRect.Controls.Add(buttonCalculate);
            tabPageZoneRect.Controls.Add(buttonOpenSVG);
            tabPageZoneRect.Controls.Add(textBoxZoneRect);
            tabPageZoneRect.Controls.Add(label15);
            tabPageZoneRect.Controls.Add(label14);
            tabPageZoneRect.Controls.Add(label12);
            tabPageZoneRect.Controls.Add(label13);
            tabPageZoneRect.Controls.Add(textBoxScaleHeight);
            tabPageZoneRect.Controls.Add(textBoxScaleWidth);
            tabPageZoneRect.Controls.Add(label11);
            tabPageZoneRect.Controls.Add(checkBoxCustomMapSize);
            tabPageZoneRect.Controls.Add(label10);
            tabPageZoneRect.Controls.Add(label9);
            tabPageZoneRect.Controls.Add(textBoxImageHeight);
            tabPageZoneRect.Controls.Add(textBoxImageWidth);
            tabPageZoneRect.Controls.Add(label8);
            tabPageZoneRect.Controls.Add(groupBox2);
            tabPageZoneRect.Controls.Add(label2);
            tabPageZoneRect.Controls.Add(label1);
            tabPageZoneRect.Controls.Add(groupBox1);
            tabPageZoneRect.Location = new Point(4, 24);
            tabPageZoneRect.Name = "tabPageZoneRect";
            tabPageZoneRect.Padding = new Padding(3);
            tabPageZoneRect.Size = new Size(468, 467);
            tabPageZoneRect.TabIndex = 0;
            tabPageZoneRect.Text = "Zone Rect";
            // 
            // menuButtonCopyZonerect
            // 
            menuButtonCopyZonerect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuButtonCopyZonerect.Location = new Point(385, 350);
            menuButtonCopyZonerect.Menu = contextMenuStripElev;
            menuButtonCopyZonerect.Name = "menuButtonCopyZonerect";
            menuButtonCopyZonerect.Size = new Size(75, 23);
            menuButtonCopyZonerect.TabIndex = 30;
            menuButtonCopyZonerect.Text = "Copy     ";
            toolTip1.SetToolTip(menuButtonCopyZonerect, "Copy zonerect, and optionally the elevations, to the clipboard");
            menuButtonCopyZonerect.UseVisualStyleBackColor = true;
            menuButtonCopyZonerect.Click += menuButtonCopyZonerect_Click;
            // 
            // contextMenuStripElev
            // 
            contextMenuStripElev.Items.AddRange(new ToolStripItem[] { includeElevationsToolStripMenuItem });
            contextMenuStripElev.Name = "contextMenuStrip1";
            contextMenuStripElev.Size = new Size(170, 26);
            contextMenuStripElev.Opening += contextMenuStripElev_Opening;
            // 
            // includeElevationsToolStripMenuItem
            // 
            includeElevationsToolStripMenuItem.Name = "includeElevationsToolStripMenuItem";
            includeElevationsToolStripMenuItem.Size = new Size(169, 22);
            includeElevationsToolStripMenuItem.Text = "Include elevations";
            includeElevationsToolStripMenuItem.Click += includeElevationsToolStripMenuItem_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(21, 175);
            label22.Name = "label22";
            label22.Size = new Size(28, 15);
            label22.TabIndex = 29;
            label22.Text = "Elev";
            toolTip1.SetToolTip(label22, "Elevations (info only, from the SVG file)");
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 10);
            label16.Name = "label16";
            label16.Size = new Size(424, 30);
            label16.TabIndex = 0;
            label16.Text = "[Open SVG] collects and calculates all fields. [Calculate] uses displayed settings.\r\nFor more info, see the Help / Description tab.";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFileName.Location = new Point(79, 394);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.ReadOnly = true;
            textBoxFileName.Size = new Size(381, 23);
            textBoxFileName.TabIndex = 20;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label17.AutoSize = true;
            label17.Location = new Point(18, 397);
            label17.Name = "label17";
            label17.Size = new Size(52, 15);
            label17.TabIndex = 19;
            label17.Text = "SVG File:";
            toolTip1.SetToolTip(label17, "File used to populate the edit boxes.");
            // 
            // buttonCalculate
            // 
            buttonCalculate.Anchor = AnchorStyles.Bottom;
            buttonCalculate.Location = new Point(257, 433);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(75, 23);
            buttonCalculate.TabIndex = 22;
            buttonCalculate.Text = "Calculate";
            toolTip1.SetToolTip(buttonCalculate, "Calculate a zone rect from current parameters.");
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // buttonOpenSVG
            // 
            buttonOpenSVG.Anchor = AnchorStyles.Bottom;
            buttonOpenSVG.Location = new Point(153, 433);
            buttonOpenSVG.Name = "buttonOpenSVG";
            buttonOpenSVG.Size = new Size(81, 23);
            buttonOpenSVG.TabIndex = 21;
            buttonOpenSVG.Text = "Open SVG...";
            toolTip1.SetToolTip(buttonOpenSVG, "Open a Mapper2 or Inkscape svg file\r\nto automatically extract and calculate values");
            buttonOpenSVG.UseVisualStyleBackColor = true;
            buttonOpenSVG.Click += buttonOpenSVG_Click;
            // 
            // textBoxZoneRect
            // 
            textBoxZoneRect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxZoneRect.DataBindings.Add(new Binding("Text", mapDataBindingSource, "zonerect", true, DataSourceUpdateMode.OnPropertyChanged));
            textBoxZoneRect.Location = new Point(79, 350);
            textBoxZoneRect.Name = "textBoxZoneRect";
            textBoxZoneRect.Size = new Size(296, 23);
            textBoxZoneRect.TabIndex = 16;
            // 
            // mapDataBindingSource
            // 
            mapDataBindingSource.DataSource = typeof(MapData);
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label15.AutoSize = true;
            label15.Location = new Point(10, 353);
            label15.Name = "label15";
            label15.Size = new Size(60, 15);
            label15.TabIndex = 15;
            label15.Text = "ZoneRect:";
            toolTip1.SetToolTip(label15, "Parameter for the Map_Styles.xml");
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.Location = new Point(12, 331);
            label14.Name = "label14";
            label14.Size = new Size(448, 2);
            label14.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(242, 277);
            label12.Name = "label12";
            label12.Size = new Size(61, 15);
            label12.TabIndex = 12;
            label12.Text = "Height (Y)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(176, 277);
            label13.Name = "label13";
            label13.Size = new Size(57, 15);
            label13.TabIndex = 10;
            label13.Text = "Width (X)";
            // 
            // textBoxScaleHeight
            // 
            textBoxScaleHeight.Location = new Point(243, 295);
            textBoxScaleHeight.Name = "textBoxScaleHeight";
            textBoxScaleHeight.Size = new Size(59, 23);
            textBoxScaleHeight.TabIndex = 13;
            textBoxScaleHeight.Text = "506";
            textBoxScaleHeight.TextAlign = HorizontalAlignment.Right;
            textBoxScaleHeight.Enter += textBox_Enter;
            textBoxScaleHeight.Validated += textBoxScaleHeight_Validated;
            // 
            // textBoxScaleWidth
            // 
            textBoxScaleWidth.Location = new Point(174, 295);
            textBoxScaleWidth.Name = "textBoxScaleWidth";
            textBoxScaleWidth.Size = new Size(59, 23);
            textBoxScaleWidth.TabIndex = 11;
            textBoxScaleWidth.Text = "436";
            textBoxScaleWidth.TextAlign = HorizontalAlignment.Right;
            textBoxScaleWidth.Enter += textBox_Enter;
            textBoxScaleWidth.Validated += textBoxScaleWidth_Validated;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(97, 298);
            label11.Name = "label11";
            label11.Size = new Size(68, 15);
            label11.TabIndex = 9;
            label11.Text = "SVG Render";
            toolTip1.SetToolTip(label11, "Dimensions after the SVG lines have been\r\nscaled to fit the Map Image Size");
            // 
            // checkBoxCustomMapSize
            // 
            checkBoxCustomMapSize.AutoSize = true;
            checkBoxCustomMapSize.Location = new Point(62, 225);
            checkBoxCustomMapSize.Name = "checkBoxCustomMapSize";
            checkBoxCustomMapSize.Size = new Size(104, 19);
            checkBoxCustomMapSize.TabIndex = 3;
            checkBoxCustomMapSize.Text = "Enable custom";
            toolTip1.SetToolTip(checkBoxCustomMapSize, "Check to edit Map Image Size");
            checkBoxCustomMapSize.UseVisualStyleBackColor = true;
            checkBoxCustomMapSize.CheckedChanged += checkBoxCustomMapSize_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(242, 215);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 7;
            label10.Text = "Height (Y)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(176, 215);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 5;
            label9.Text = "Width (X)";
            // 
            // textBoxImageHeight
            // 
            textBoxImageHeight.DataBindings.Add(new Binding("Text", mapDataBindingSource, "imageHeight", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxImageHeight.Location = new Point(243, 233);
            textBoxImageHeight.Name = "textBoxImageHeight";
            textBoxImageHeight.ReadOnly = true;
            textBoxImageHeight.Size = new Size(59, 23);
            textBoxImageHeight.TabIndex = 8;
            textBoxImageHeight.Text = "506";
            textBoxImageHeight.TextAlign = HorizontalAlignment.Right;
            textBoxImageHeight.TextChanged += textBoxZRInput_TextChanged;
            textBoxImageHeight.Enter += textBox_Enter;
            // 
            // textBoxImageWidth
            // 
            textBoxImageWidth.DataBindings.Add(new Binding("Text", mapDataBindingSource, "imageWidth", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxImageWidth.Location = new Point(174, 233);
            textBoxImageWidth.Name = "textBoxImageWidth";
            textBoxImageWidth.ReadOnly = true;
            textBoxImageWidth.Size = new Size(59, 23);
            textBoxImageWidth.TabIndex = 6;
            textBoxImageWidth.Text = "436";
            textBoxImageWidth.TextAlign = HorizontalAlignment.Right;
            textBoxImageWidth.TextChanged += textBoxZRInput_TextChanged;
            textBoxImageWidth.Enter += textBox_Enter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(78, 243);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 4;
            label8.Text = "Map Image Size";
            toolTip1.SetToolTip(label8, "The final size of the scaled map.");
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxMapBY);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBoxMapAY);
            groupBox2.Controls.Add(textBoxMapBX);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBoxMapAX);
            groupBox2.Location = new Point(256, 62);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(177, 105);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Map crosshair coordinates";
            toolTip1.SetToolTip(groupBox2, "The locations of the crosshairs\r\nafter the lines have been scaled\r\nto fit the map size.");
            // 
            // textBoxMapBY
            // 
            textBoxMapBY.DataBindings.Add(new Binding("Text", mapDataBindingSource, "crosshairBY", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxMapBY.Location = new Point(94, 65);
            textBoxMapBY.Name = "textBoxMapBY";
            textBoxMapBY.Size = new Size(59, 23);
            textBoxMapBY.TabIndex = 5;
            textBoxMapBY.TextAlign = HorizontalAlignment.Right;
            textBoxMapBY.TextChanged += textBoxZRInput_TextChanged;
            textBoxMapBY.Enter += textBox_Enter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(115, 16);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 2;
            label5.Text = "Y";
            // 
            // textBoxMapAY
            // 
            textBoxMapAY.DataBindings.Add(new Binding("Text", mapDataBindingSource, "crosshairAY", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxMapAY.Location = new Point(94, 36);
            textBoxMapAY.Name = "textBoxMapAY";
            textBoxMapAY.Size = new Size(59, 23);
            textBoxMapAY.TabIndex = 3;
            textBoxMapAY.TextAlign = HorizontalAlignment.Right;
            textBoxMapAY.TextChanged += textBoxZRInput_TextChanged;
            textBoxMapAY.Enter += textBox_Enter;
            // 
            // textBoxMapBX
            // 
            textBoxMapBX.DataBindings.Add(new Binding("Text", mapDataBindingSource, "crosshairBX", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxMapBX.Location = new Point(20, 65);
            textBoxMapBX.Name = "textBoxMapBX";
            textBoxMapBX.Size = new Size(59, 23);
            textBoxMapBX.TabIndex = 4;
            textBoxMapBX.TextAlign = HorizontalAlignment.Right;
            textBoxMapBX.TextChanged += textBoxZRInput_TextChanged;
            textBoxMapBX.Enter += textBox_Enter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 16);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 0;
            label6.Text = "&X";
            // 
            // textBoxMapAX
            // 
            textBoxMapAX.DataBindings.Add(new Binding("Text", mapDataBindingSource, "crosshairAX", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "F0"));
            textBoxMapAX.Location = new Point(20, 36);
            textBoxMapAX.Name = "textBoxMapAX";
            textBoxMapAX.Size = new Size(59, 23);
            textBoxMapAX.TabIndex = 1;
            textBoxMapAX.TextAlign = HorizontalAlignment.Right;
            textBoxMapAX.TextChanged += textBoxZRInput_TextChanged;
            textBoxMapAX.Enter += textBox_Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 130);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "Point B";
            toolTip1.SetToolTip(label2, "Lower Right");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 103);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Point A";
            toolTip1.SetToolTip(label1, "Upper Left");
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(textBoxGameBY);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBoxMaxEl);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBoxGameAY);
            groupBox1.Controls.Add(textBoxMinEl);
            groupBox1.Controls.Add(textBoxGameBX);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxGameAX);
            groupBox1.Location = new Point(59, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(178, 139);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "In Game /loc coordinates";
            toolTip1.SetToolTip(groupBox1, "The UL, LR, and Ele points from the SVG file.\r\nThey are displayed at the bottom in the SVG editor.\r\nOr populated automatically when reading the SVG file.");
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(105, 92);
            label21.Name = "label21";
            label21.Size = new Size(30, 15);
            label21.TabIndex = 8;
            label21.Text = "Max";
            // 
            // textBoxGameBY
            // 
            textBoxGameBY.DataBindings.Add(new Binding("Text", mapDataBindingSource, "LRY", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "N2"));
            textBoxGameBY.Location = new Point(94, 65);
            textBoxGameBY.Name = "textBoxGameBY";
            textBoxGameBY.Size = new Size(59, 23);
            textBoxGameBY.TabIndex = 5;
            textBoxGameBY.TextAlign = HorizontalAlignment.Right;
            textBoxGameBY.TextChanged += textBoxZRInput_TextChanged;
            textBoxGameBY.Enter += textBox_Enter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 92);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 6;
            label7.Text = "Min";
            // 
            // textBoxMaxEl
            // 
            textBoxMaxEl.Location = new Point(94, 109);
            textBoxMaxEl.Name = "textBoxMaxEl";
            textBoxMaxEl.ReadOnly = true;
            textBoxMaxEl.Size = new Size(59, 23);
            textBoxMaxEl.TabIndex = 9;
            textBoxMaxEl.TabStop = false;
            textBoxMaxEl.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 16);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 2;
            label4.Text = "Y";
            // 
            // textBoxGameAY
            // 
            textBoxGameAY.DataBindings.Add(new Binding("Text", mapDataBindingSource, "ULY", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "N2"));
            textBoxGameAY.Location = new Point(94, 36);
            textBoxGameAY.Name = "textBoxGameAY";
            textBoxGameAY.Size = new Size(59, 23);
            textBoxGameAY.TabIndex = 3;
            textBoxGameAY.TextAlign = HorizontalAlignment.Right;
            textBoxGameAY.TextChanged += textBoxZRInput_TextChanged;
            textBoxGameAY.Enter += textBox_Enter;
            // 
            // textBoxMinEl
            // 
            textBoxMinEl.Location = new Point(20, 109);
            textBoxMinEl.Name = "textBoxMinEl";
            textBoxMinEl.ReadOnly = true;
            textBoxMinEl.Size = new Size(59, 23);
            textBoxMinEl.TabIndex = 7;
            textBoxMinEl.TabStop = false;
            textBoxMinEl.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxGameBX
            // 
            textBoxGameBX.DataBindings.Add(new Binding("Text", mapDataBindingSource, "LRX", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "N2"));
            textBoxGameBX.Location = new Point(20, 65);
            textBoxGameBX.Name = "textBoxGameBX";
            textBoxGameBX.Size = new Size(59, 23);
            textBoxGameBX.TabIndex = 4;
            textBoxGameBX.TextAlign = HorizontalAlignment.Right;
            textBoxGameBX.TextChanged += textBoxZRInput_TextChanged;
            textBoxGameBX.Enter += textBox_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 16);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 0;
            label3.Text = "X";
            // 
            // textBoxGameAX
            // 
            textBoxGameAX.DataBindings.Add(new Binding("Text", mapDataBindingSource, "ULX", true, DataSourceUpdateMode.OnPropertyChanged, "double.NaN", "N2"));
            textBoxGameAX.Location = new Point(20, 36);
            textBoxGameAX.Name = "textBoxGameAX";
            textBoxGameAX.Size = new Size(59, 23);
            textBoxGameAX.TabIndex = 1;
            textBoxGameAX.TextAlign = HorizontalAlignment.Right;
            textBoxGameAX.TextChanged += textBoxZRInput_TextChanged;
            textBoxGameAX.Enter += textBox_Enter;
            // 
            // tabPageMapLoc
            // 
            tabPageMapLoc.BackColor = SystemColors.Control;
            tabPageMapLoc.Controls.Add(label34);
            tabPageMapLoc.Controls.Add(checkBoxLoadMapstyles);
            tabPageMapLoc.Controls.Add(buttonOpenMapStyle);
            tabPageMapLoc.Controls.Add(label33);
            tabPageMapLoc.Controls.Add(comboBoxMapStyles);
            tabPageMapLoc.Controls.Add(buttonMapLocCalc);
            tabPageMapLoc.Controls.Add(textBoxMapLocation);
            tabPageMapLoc.Controls.Add(label32);
            tabPageMapLoc.Controls.Add(label29);
            tabPageMapLoc.Controls.Add(buttonPasteMapSize);
            tabPageMapLoc.Controls.Add(checkBoxCustomMapLocMapSize);
            tabPageMapLoc.Controls.Add(label26);
            tabPageMapLoc.Controls.Add(label27);
            tabPageMapLoc.Controls.Add(textBoxMapLocHeight);
            tabPageMapLoc.Controls.Add(textBoxMapLocWidth);
            tabPageMapLoc.Controls.Add(label28);
            tabPageMapLoc.Controls.Add(buttonPasteZoneRect);
            tabPageMapLoc.Controls.Add(textBoxMapLocZoneRect);
            tabPageMapLoc.Controls.Add(label25);
            tabPageMapLoc.Controls.Add(groupBox3);
            tabPageMapLoc.Location = new Point(4, 24);
            tabPageMapLoc.Name = "tabPageMapLoc";
            tabPageMapLoc.Padding = new Padding(3);
            tabPageMapLoc.Size = new Size(468, 467);
            tabPageMapLoc.TabIndex = 5;
            tabPageMapLoc.Text = "Map Loc";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(10, 12);
            label34.Name = "label34";
            label34.Size = new Size(338, 15);
            label34.TabIndex = 19;
            label34.Text = "Convert an in-game /loc to map coordinates using a zone rect.";
            // 
            // checkBoxLoadMapstyles
            // 
            checkBoxLoadMapstyles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxLoadMapstyles.AutoSize = true;
            checkBoxLoadMapstyles.Location = new Point(352, 211);
            checkBoxLoadMapstyles.Name = "checkBoxLoadMapstyles";
            checkBoxLoadMapstyles.Size = new Size(105, 19);
            checkBoxLoadMapstyles.TabIndex = 7;
            checkBoxLoadMapstyles.Text = "Load at startup";
            checkBoxLoadMapstyles.UseVisualStyleBackColor = true;
            // 
            // buttonOpenMapStyle
            // 
            buttonOpenMapStyle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpenMapStyle.AutoSize = true;
            buttonOpenMapStyle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOpenMapStyle.Location = new Point(317, 207);
            buttonOpenMapStyle.Name = "buttonOpenMapStyle";
            buttonOpenMapStyle.Size = new Size(26, 25);
            buttonOpenMapStyle.TabIndex = 6;
            buttonOpenMapStyle.Text = "...";
            toolTip1.SetToolTip(buttonOpenMapStyle, "Browse for a MapStyles.xml file in your EQII UI folder");
            buttonOpenMapStyle.UseVisualStyleBackColor = true;
            buttonOpenMapStyle.Click += buttonOpenMapStyle_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(32, 212);
            label33.Name = "label33";
            label33.Size = new Size(62, 15);
            label33.TabIndex = 4;
            label33.Text = "Map Style:";
            toolTip1.SetToolTip(label33, "Get a ZoneRect from a MapStyles file");
            // 
            // comboBoxMapStyles
            // 
            comboBoxMapStyles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMapStyles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxMapStyles.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxMapStyles.FormattingEnabled = true;
            comboBoxMapStyles.Location = new Point(100, 209);
            comboBoxMapStyles.Name = "comboBoxMapStyles";
            comboBoxMapStyles.Size = new Size(211, 23);
            comboBoxMapStyles.TabIndex = 5;
            comboBoxMapStyles.SelectedIndexChanged += comboBoxMapStyles_SelectedIndexChanged;
            // 
            // buttonMapLocCalc
            // 
            buttonMapLocCalc.Anchor = AnchorStyles.Bottom;
            buttonMapLocCalc.Location = new Point(193, 424);
            buttonMapLocCalc.Name = "buttonMapLocCalc";
            buttonMapLocCalc.Size = new Size(75, 23);
            buttonMapLocCalc.TabIndex = 18;
            buttonMapLocCalc.Text = "Calculate";
            toolTip1.SetToolTip(buttonMapLocCalc, "Calculate map location");
            buttonMapLocCalc.UseVisualStyleBackColor = true;
            buttonMapLocCalc.Click += buttonMapLocCalc_Click;
            // 
            // textBoxMapLocation
            // 
            textBoxMapLocation.Anchor = AnchorStyles.Top;
            textBoxMapLocation.Location = new Point(186, 358);
            textBoxMapLocation.Name = "textBoxMapLocation";
            textBoxMapLocation.Size = new Size(100, 23);
            textBoxMapLocation.TabIndex = 17;
            textBoxMapLocation.TextAlign = HorizontalAlignment.Center;
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.Top;
            label32.AutoSize = true;
            label32.Location = new Point(100, 361);
            label32.Name = "label32";
            label32.Size = new Size(80, 15);
            label32.TabIndex = 16;
            label32.Text = "Map Location";
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label29.BorderStyle = BorderStyle.Fixed3D;
            label29.Location = new Point(10, 331);
            label29.Name = "label29";
            label29.Size = new Size(448, 2);
            label29.TabIndex = 15;
            // 
            // buttonPasteMapSize
            // 
            buttonPasteMapSize.Anchor = AnchorStyles.Top;
            buttonPasteMapSize.Image = (Image)resources.GetObject("buttonPasteMapSize.Image");
            buttonPasteMapSize.Location = new Point(293, 289);
            buttonPasteMapSize.Name = "buttonPasteMapSize";
            buttonPasteMapSize.Size = new Size(26, 25);
            buttonPasteMapSize.TabIndex = 14;
            toolTip1.SetToolTip(buttonPasteMapSize, "Paste from Zone Rect tab");
            buttonPasteMapSize.UseVisualStyleBackColor = true;
            buttonPasteMapSize.Click += buttonPasteMapSize_Click;
            // 
            // checkBoxCustomMapLocMapSize
            // 
            checkBoxCustomMapLocMapSize.Anchor = AnchorStyles.Top;
            checkBoxCustomMapLocMapSize.AutoSize = true;
            checkBoxCustomMapLocMapSize.Location = new Point(46, 282);
            checkBoxCustomMapLocMapSize.Name = "checkBoxCustomMapLocMapSize";
            checkBoxCustomMapLocMapSize.Size = new Size(107, 19);
            checkBoxCustomMapLocMapSize.TabIndex = 8;
            checkBoxCustomMapLocMapSize.Text = " Enable custom";
            toolTip1.SetToolTip(checkBoxCustomMapLocMapSize, "Check to edit Map Image Size");
            checkBoxCustomMapLocMapSize.UseVisualStyleBackColor = true;
            checkBoxCustomMapLocMapSize.CheckedChanged += checkBoxCustomMapLocMapSize_CheckedChanged;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top;
            label26.AutoSize = true;
            label26.Location = new Point(226, 271);
            label26.Name = "label26";
            label26.Size = new Size(61, 15);
            label26.TabIndex = 12;
            label26.Text = "Height (Y)";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Top;
            label27.AutoSize = true;
            label27.Location = new Point(160, 271);
            label27.Name = "label27";
            label27.Size = new Size(57, 15);
            label27.TabIndex = 10;
            label27.Text = "Width (X)";
            // 
            // textBoxMapLocHeight
            // 
            textBoxMapLocHeight.Anchor = AnchorStyles.Top;
            textBoxMapLocHeight.Location = new Point(227, 290);
            textBoxMapLocHeight.Name = "textBoxMapLocHeight";
            textBoxMapLocHeight.ReadOnly = true;
            textBoxMapLocHeight.Size = new Size(59, 23);
            textBoxMapLocHeight.TabIndex = 13;
            textBoxMapLocHeight.Text = "506";
            textBoxMapLocHeight.TextAlign = HorizontalAlignment.Right;
            textBoxMapLocHeight.TextChanged += textBoxMapLoc_TextChanged;
            // 
            // textBoxMapLocWidth
            // 
            textBoxMapLocWidth.Anchor = AnchorStyles.Top;
            textBoxMapLocWidth.Location = new Point(158, 290);
            textBoxMapLocWidth.Name = "textBoxMapLocWidth";
            textBoxMapLocWidth.ReadOnly = true;
            textBoxMapLocWidth.Size = new Size(59, 23);
            textBoxMapLocWidth.TabIndex = 11;
            textBoxMapLocWidth.Text = "436";
            textBoxMapLocWidth.TextAlign = HorizontalAlignment.Right;
            textBoxMapLocWidth.TextChanged += textBoxMapLoc_TextChanged;
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Top;
            label28.AutoSize = true;
            label28.Location = new Point(62, 300);
            label28.Name = "label28";
            label28.Size = new Size(90, 15);
            label28.TabIndex = 9;
            label28.Text = "Map Image Size";
            toolTip1.SetToolTip(label28, "The final size of the scaled map.");
            // 
            // buttonPasteZoneRect
            // 
            buttonPasteZoneRect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPasteZoneRect.Image = (Image)resources.GetObject("buttonPasteZoneRect.Image");
            buttonPasteZoneRect.Location = new Point(317, 167);
            buttonPasteZoneRect.Name = "buttonPasteZoneRect";
            buttonPasteZoneRect.Size = new Size(26, 25);
            buttonPasteZoneRect.TabIndex = 3;
            toolTip1.SetToolTip(buttonPasteZoneRect, "Paste from Zone Rect tab");
            buttonPasteZoneRect.UseVisualStyleBackColor = true;
            buttonPasteZoneRect.Click += buttonPasteZoneRect_Click;
            // 
            // textBoxMapLocZoneRect
            // 
            textBoxMapLocZoneRect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMapLocZoneRect.Location = new Point(100, 168);
            textBoxMapLocZoneRect.Name = "textBoxMapLocZoneRect";
            textBoxMapLocZoneRect.Size = new Size(211, 23);
            textBoxMapLocZoneRect.TabIndex = 2;
            textBoxMapLocZoneRect.TextChanged += textBoxMapLoc_TextChanged;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(34, 173);
            label25.Name = "label25";
            label25.Size = new Size(60, 15);
            label25.TabIndex = 1;
            label25.Text = "ZoneRect:";
            toolTip1.SetToolTip(label25, "Four numbers are required. Any other text is ignored.");
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top;
            groupBox3.Controls.Add(buttonPasteLoc);
            groupBox3.Controls.Add(label30);
            groupBox3.Controls.Add(textBoxMapLocY);
            groupBox3.Controls.Add(label31);
            groupBox3.Controls.Add(textBoxMapLocX);
            groupBox3.Location = new Point(142, 37);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(170, 111);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "In Game /loc coordinates";
            toolTip1.SetToolTip(groupBox3, "The UL, LR, and Ele points from the SVG file.\r\nThey are displayed at the bottom in the SVG editor.\r\nOr populated automatically when reading the SVG file.");
            // 
            // buttonPasteLoc
            // 
            buttonPasteLoc.Location = new Point(45, 72);
            buttonPasteLoc.Name = "buttonPasteLoc";
            buttonPasteLoc.Size = new Size(75, 23);
            buttonPasteLoc.TabIndex = 4;
            buttonPasteLoc.Text = "Paste";
            toolTip1.SetToolTip(buttonPasteLoc, "Paste from in-game /loc clipboard");
            buttonPasteLoc.UseVisualStyleBackColor = true;
            buttonPasteLoc.Click += buttonPasteLoc_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(115, 16);
            label30.Name = "label30";
            label30.Size = new Size(14, 15);
            label30.TabIndex = 2;
            label30.Text = "Y";
            // 
            // textBoxMapLocY
            // 
            textBoxMapLocY.Location = new Point(94, 36);
            textBoxMapLocY.Name = "textBoxMapLocY";
            textBoxMapLocY.Size = new Size(59, 23);
            textBoxMapLocY.TabIndex = 3;
            textBoxMapLocY.TextAlign = HorizontalAlignment.Right;
            textBoxMapLocY.TextChanged += textBoxMapLoc_TextChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(41, 16);
            label31.Name = "label31";
            label31.Size = new Size(14, 15);
            label31.TabIndex = 0;
            label31.Text = "X";
            // 
            // textBoxMapLocX
            // 
            textBoxMapLocX.Location = new Point(20, 36);
            textBoxMapLocX.Name = "textBoxMapLocX";
            textBoxMapLocX.Size = new Size(59, 23);
            textBoxMapLocX.TabIndex = 1;
            textBoxMapLocX.TextAlign = HorizontalAlignment.Right;
            textBoxMapLocX.TextChanged += textBoxMapLoc_TextChanged;
            // 
            // tabPageLines
            // 
            tabPageLines.Controls.Add(dataGridView1);
            tabPageLines.Location = new Point(4, 24);
            tabPageLines.Name = "tabPageLines";
            tabPageLines.Padding = new Padding(3);
            tabPageLines.Size = new Size(468, 467);
            tabPageLines.TabIndex = 4;
            tabPageLines.Text = "Line Index";
            tabPageLines.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { svgIdDataGridViewTextBoxColumn, lineNumberDataGridViewTextBoxColumn });
            dataGridView1.DataSource = lineIndexBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(462, 461);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            // 
            // svgIdDataGridViewTextBoxColumn
            // 
            svgIdDataGridViewTextBoxColumn.DataPropertyName = "svgId";
            svgIdDataGridViewTextBoxColumn.HeaderText = "SVG line Id";
            svgIdDataGridViewTextBoxColumn.Name = "svgIdDataGridViewTextBoxColumn";
            svgIdDataGridViewTextBoxColumn.ReadOnly = true;
            svgIdDataGridViewTextBoxColumn.ToolTipText = "SVG ID for the line";
            // 
            // lineNumberDataGridViewTextBoxColumn
            // 
            lineNumberDataGridViewTextBoxColumn.DataPropertyName = "lineNumber";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            lineNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            lineNumberDataGridViewTextBoxColumn.HeaderText = "Line Number";
            lineNumberDataGridViewTextBoxColumn.Name = "lineNumberDataGridViewTextBoxColumn";
            lineNumberDataGridViewTextBoxColumn.ReadOnly = true;
            lineNumberDataGridViewTextBoxColumn.ToolTipText = "Line number in the clean log file";
            // 
            // lineIndexBindingSource
            // 
            lineIndexBindingSource.DataSource = typeof(LineIndex);
            // 
            // tabPageHelp
            // 
            tabPageHelp.Controls.Add(richTextBox2);
            tabPageHelp.Location = new Point(4, 24);
            tabPageHelp.Name = "tabPageHelp";
            tabPageHelp.Padding = new Padding(3);
            tabPageHelp.Size = new Size(468, 467);
            tabPageHelp.TabIndex = 2;
            tabPageHelp.Text = "Help / Description";
            tabPageHelp.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Dock = DockStyle.Fill;
            richTextBox2.Location = new Point(3, 3);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(462, 461);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "";
            richTextBox2.LinkClicked += richTextBox2_LinkClicked;
            // 
            // contextMenuStripStyles
            // 
            contextMenuStripStyles.Name = "contextMenuStripStyles";
            contextMenuStripStyles.Size = new Size(61, 4);
            // 
            // mapStylesBindingSource
            // 
            mapStylesBindingSource.DataSource = typeof(MapStyles);
            // 
            // openFileDialogSvg
            // 
            openFileDialogSvg.Filter = "SVG files|*.svg|All files|*.*";
            // 
            // openFileDialogTxt
            // 
            openFileDialogTxt.Filter = "Log files|eq2log_*.txt|All files|*.*";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 495);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(476, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // openFileDialogXml
            // 
            openFileDialogXml.Filter = "XML files|*.xml|All files|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(476, 517);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "EQ2MAP Tools";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            tabControl1.ResumeLayout(false);
            tabPageMapper.ResumeLayout(false);
            tabPageMapper.PerformLayout();
            groupBoxSvg.ResumeLayout(false);
            groupBoxSvg.PerformLayout();
            groupBoxMapper.ResumeLayout(false);
            groupBoxMapper.PerformLayout();
            tabPageZoneRect.ResumeLayout(false);
            tabPageZoneRect.PerformLayout();
            contextMenuStripElev.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapDataBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPageMapLoc.ResumeLayout(false);
            tabPageMapLoc.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPageLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lineIndexBindingSource).EndInit();
            tabPageHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapStylesBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageZoneRect;
        private Button buttonCalculate;
        private Button buttonOpenSVG;
        private TextBox textBoxZoneRect;
        private Label label15;
        private Label label14;
        private Label label12;
        private Label label13;
        private TextBox textBoxScaleHeight;
        private TextBox textBoxScaleWidth;
        private Label label11;
        private CheckBox checkBoxCustomMapSize;
        private Label label10;
        private Label label9;
        private TextBox textBoxImageHeight;
        private TextBox textBoxImageWidth;
        private Label label8;
        private GroupBox groupBox2;
        private TextBox textBoxMapBY;
        private Label label5;
        private TextBox textBoxMapAY;
        private TextBox textBoxMapBX;
        private Label label6;
        private TextBox textBoxMapAX;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBoxGameBY;
        private Label label4;
        private TextBox textBoxGameAY;
        private TextBox textBoxGameBX;
        private Label label3;
        private TextBox textBoxGameAX;
        private OpenFileDialog openFileDialogSvg;
        private ToolTip toolTip1;
        private TextBox textBoxFileName;
        private Label label17;
        private Label label16;
        private TabPage tabPageHelp;
        private RichTextBox richTextBox2;
        private Label label21;
        private TextBox textBoxMaxEl;
        private Label label7;
        private TextBox textBoxMinEl;
        private Label label22;
        private TabPage tabPageMapper;
        private Button buttonLogBrowse;
        private TextBox textBoxLogFile;
        private Label label18;
        private OpenFileDialog openFileDialogTxt;
        private TextBox textBoxMapLevel;
        private Label label23;
        private TextBox textBoxMapName;
        private Label label20;
        private Button buttonOutputFolder;
        private TextBox textBoxOutputFolder;
        private Label label19;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonRunMapper;
        private Label label24;
        private TextBox textBoxElevations;
        private CheckBox checkBoxLaunchInkscape;
        private CheckBox checkBoxLaunchDefault;
        private GroupBox groupBoxMapper;
        private RadioButton radioButtonBuildMapper;
        private RadioButton radioButtonAppendMapper;
        private RadioButton radioButtonExistingMapper;
        private GroupBox groupBoxSvg;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox textBoxDefaultSvgName;
        private TextBox textBoxInkscapeName;
        private BindingSource mapDataBindingSource;
        private TabPage tabPageLines;
        private DataGridView dataGridView1;
        private BindingSource lineIndexBindingSource;
        private DataGridViewTextBoxColumn svgIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lineNumberDataGridViewTextBoxColumn;
        private TabPage tabPageMapLoc;
        private Button buttonMapLocCalc;
        private TextBox textBoxMapLocation;
        private Label label32;
        private Label label29;
        private Button buttonPasteMapSize;
        private CheckBox checkBoxCustomMapLocMapSize;
        private Label label26;
        private Label label27;
        private TextBox textBoxMapLocHeight;
        private TextBox textBoxMapLocWidth;
        private Label label28;
        private Button buttonPasteZoneRect;
        private TextBox textBoxMapLocZoneRect;
        private Label label25;
        private GroupBox groupBox3;
        private Button buttonPasteLoc;
        private Label label30;
        private TextBox textBoxMapLocY;
        private Label label31;
        private TextBox textBoxMapLocX;
        private Label label33;
        private ComboBox comboBoxMapStyles;
        private Button buttonOpenMapStyle;
        private BindingSource mapStylesBindingSource;
        private OpenFileDialog openFileDialogXml;
        private CheckBox checkBoxLoadMapstyles;
        private Label label34;
        private MenuButton menuButtonCopyZonerect;
        private ContextMenuStrip contextMenuStripElev;
        private ToolStripMenuItem includeElevationsToolStripMenuItem;
        private Button buttonFindMapName;
        private ContextMenuStrip contextMenuStripStyles;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label label36;
        private Label label35;
        private Button buttonScanDates;
    }
}