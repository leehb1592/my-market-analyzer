﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;

namespace MyMarketAnalyzer
{
    public enum MarketRegion
    {
        [StringValue("Canada")]
        CA,
        [StringValue("United States")]
        US,
        [StringValue("Europe")]
        EU,
        [StringValue("Asia/Pacific")]
        AP,
        [StringValue("Americas")]
        AM,
        [StringValue("Middle East")]
        ME
    }

    public partial class MainForm : Form
    {   
        /******* These Lists must be the same size ********/
        private MarketRegion[] RegionDropDownList = { 
                                                        MarketRegion.CA, MarketRegion.US, MarketRegion.EU, MarketRegion.AP
                                                    };

        private Image[] RegionImageList = {
                                              MyMarketAnalyzer.Properties.Resources.fl_CA, MyMarketAnalyzer.Properties.Resources.fl_US,
                                              MyMarketAnalyzer.Properties.Resources.fl_EU, MyMarketAnalyzer.Properties.Resources.fl_AP
                                          };
        /**************************************************/

        private String[,] HistoricalFilterKey = { {TableHeadings.PctChange[0], TableHeadings.PctChange[1]},
                                                  {TableHeadings.Hist_Avg[0], TableHeadings.Hist_Avg[1]}, 
                                                  {TableHeadings.Hist_Vlty, TableHeadings.Hist_Vlty} };
        
        private String[,] LiveFilterKey = { { TableHeadings.PctChange[0], TableHeadings.PctChange[1] }, 
                                          { TableHeadings.Live_Last, TableHeadings.Live_Last }, 
                                          { TableHeadings.Live_Vol, TableHeadings.Live_Vol } };
        private int[] LiveSessionIntervalsSec = { 15, 30, 60, 300 };

        //***** CONSTANTS *****//
        private const UInt32 WM_NOTIFY = 0x004E;
        private const UInt32 WM_CELLCLICK = 0xA000;
        private const UInt32 WM_MULTIROWCLICK = 0xA001;
        private const UInt32 WM_SHOWBTNCLICK = 0xA002;
        private const UInt32 WM_SHOWNEWWINDCLICK = 0xA003;
        private const UInt32 WM_PROCESS_TI = 0xA004;
        private const UInt32 WM_LIVEUPDATE = 0xA005;
        private const UInt32 WM_UPDATING_DATA = 0xA006;
        private const UInt32 WM_ADDWATCHLIST = 0xA007;
        private const UInt32 WM_MULTI_ADDWATCHLIST = 0xA008;
        private const UInt32 WM_LIVESESSIONCLOSED = 0xA009;

        //***** PRIVATE GLOBALS *****//
        private TabPage tabVisuals;
        private VisualsTab tabVisualsControl;

        private DataManager MyDataManager;
        private AlgorithmDesignForm AlgDesignForm = null;

        private int AnalysisDisplayIndex = 0;
        private Rectangle InitialSize = new Rectangle();
        private bool DataMenuPanelVisible = false;

        /*****************************************************************************
         *  CONSTRUCTOR: MainForm
         *  Description: Creates the main Windows Form for the application
         *****************************************************************************/
        public MainForm()
        {
            InitializeComponent();

            tblStatTableMain.ResetRows(1);
            tabControl1.SelectedIndex = 1;

            MyDataManager = new DataManager(this.Handle);

            tabVisuals = null;
            tabVisualsControl = null;
            InitialSize = this.analysisSplitContainer.Panel1.ClientRectangle;
            tabControl1.TabPages.Remove(this.tabPage1);
            AlgDesignForm = new AlgorithmDesignForm(ref MyDataManager);

            InitializeMainForm();
            InitializeAnalysisForm();
            CollapseMenuPanel();
        }

        /*****************************************************************************
         *  FUNCTION:       InitializeMainForm
         *  Description:    Initializes / configures general controls and parameters on
         *                  the MainForm window
         *  Parameters:     None
         *****************************************************************************/
        private void InitializeMainForm()
        {
            int i;

            MyDataManager.LoadMarketRegionConfig(RegionDropDownList);

            if (RegionDropDownList.Length > 0)
            {
                for (i = 0; i < RegionDropDownList.Length; i++)
                {
                    this.cbRegionSelect.Items.Add(StringEnum.GetStringValue(RegionDropDownList[i]));
                }
                this.cbRegionSelect.SelectedIndex = 0;
            }
            SetLiveDataIntervalOptions();
        }

        /*****************************************************************************
         *  FUNCTION:       InitializeAnalysisForm
         *  Description:    Initializes / configures controls on the Analysis tab page
         *  Parameters:     None
         *****************************************************************************/
        private void InitializeAnalysisForm()
        {
            int i;

            for(i = 0; i < Analysis.ChartTypes.Length; i++)
            {
                cbAnalysisType.Items.Add(Analysis.ChartTypes[i]);
            }

            for (i = 0; i < Analysis.ChartFeatures.Length; i++)
            {
                cbAnalysisIndicatorX.Items.Add(Analysis.ChartFeatures[i]);
                cbAnalysisIndicatorY.Items.Add(Analysis.ChartFeatures[i]);
            }

            //Additional Control initialization
            this.btnBuyRuleExpandCollapse.FlatStyle = FlatStyle.Flat;
            this.btnBuyRuleExpandCollapse.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            this.btnSellRuleExpandCollapse.FlatStyle = FlatStyle.Flat;
            this.btnSellRuleExpandCollapse.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        /*****************************************************************************
         *  FUNCTION:       CollapseMenuPanel
         *  Description:    
         *  Parameters:     
         *****************************************************************************/
        private void CollapseMenuPanel()
        {
            this.dataMenuPanel.Size = this.dataMenuArrow.Size;
            this.dataMenuPanel.Location = new Point(this.tabStats.Width - this.dataMenuArrow.Width - 4, 0);
            DataMenuPanelVisible = false;
            this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_normal;
        }

        /*****************************************************************************
         *  FUNCTION:       ExpandMenuPanel
         *  Description:    
         *  Parameters:     
         *****************************************************************************/
        private void ExpandMenuPanel()
        {
            this.dataMenuPanel.Size = new Size(120, this.tabStats.Height);
            this.dataMenuPanel.Location = new Point(this.tabStats.Width - 120, 0);
            DataMenuPanelVisible = true;
            this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_normal_rev;
        }

        /*****************************************************************************
         *  FUNCTION:       SetDisplayHistoricalDataStatus
         *  Description:    Updates the displayed Historical Data load status
         *  Parameters:     
         *          pIsLoaded - True if historical data set has been loaded, False otherwise
         *****************************************************************************/
        private void SetDisplayHistoricalDataStatus(bool pIsLoaded)
        {
            int i;
            Label[] HistStatusLabels = { this.lblHistDataStatus1, this.lblHistDataStatus2 };
            ToolStripTextBox[] HistSourceDir = { this.tsHistSourceDir1, this.tsHistSourceDir2 };

            if (pIsLoaded)
            {
                for (i = 0; i < HistStatusLabels.Length; i++)
                {
                    HistStatusLabels[i].Text = "LOADED";
                    HistStatusLabels[i].ForeColor = Color.Green;
                    HistSourceDir[i].Text = MyDataManager.HistoricalDataSource;
                }
            }
            else
            {
                for (i = 0; i < HistStatusLabels.Length; i++)
                {
                    HistStatusLabels[i].Text = "UNAVAILABLE";
                    HistStatusLabels[i].ForeColor = Color.Red;
                    HistSourceDir[i].Text = "";
                }
            }
        }

        /*****************************************************************************
         *  FUNCTION:       SetDisplayLiveDataStatus
         *  Description:    Updates the displayed Live Data Session Connection status
         *  Parameters:     
         *          pIsLoaded - True if live data connection is open, False otherwise
         *****************************************************************************/
        private void SetDisplayLiveDataStatus(bool pIsLoaded)
        {
            int i;
            Label[] LiveStatusLabels = { this.lblLiveDataStatus1, this.lblLiveDataStatus2 };

            if (pIsLoaded)
            {
                for (i = 0; i < LiveStatusLabels.Length; i++)
                {
                    LiveStatusLabels[i].Text = "OPEN";
                    LiveStatusLabels[i].ForeColor = Color.Green;
                }
            }
            else
            {
                for (i = 0; i < LiveStatusLabels.Length; i++)
                {
                    LiveStatusLabels[i].Text = "CLOSED";
                    LiveStatusLabels[i].ForeColor = Color.Red;
                }
            }
        }

        /*****************************************************************************
         *  FUNCTION:       SetLiveDataIntervalOptions
         *  Description:    Populates the drop-down menu for selecting the interval at
         *                  which to request new live data
         *  Parameters:     
         *****************************************************************************/
        private void SetLiveDataIntervalOptions()
        {
            int i;
            string option_temp;

            this.cbLiveDataInterval.Items.Clear();
            for(i = 0; i < this.LiveSessionIntervalsSec.Count(); i++)
            {
                if(LiveSessionIntervalsSec[i] >= 60)
                {
                    option_temp = (LiveSessionIntervalsSec[i] / 60).ToString() + " min";
                }
                else
                {
                    option_temp = LiveSessionIntervalsSec[i].ToString() + " sec";
                }

                if ((LiveSessionIntervalsSec[i] >= 10 && LiveSessionIntervalsSec[i] < 60) ||
                    (LiveSessionIntervalsSec[i] >= 600 && LiveSessionIntervalsSec[i] < 6000))
                {
                    option_temp = " " + option_temp;
                }
                else if (LiveSessionIntervalsSec[i] < 10 || LiveSessionIntervalsSec[i] >= 60)
                {
                    option_temp = "   " + option_temp;
                }
                else { }

                this.cbLiveDataInterval.Items.Add(option_temp);
            }
        }

        /*****************************************************************************
         *  FUNCTION:       ClearFilter
         *  Description:    Clears the drop-down filter input
         *  Parameters:     
         *****************************************************************************/
        private void ClearFilter()
        {
            tblStatTableMain.SetFilterExpression(tabStats.Handle, "");

            if (MyDataManager.HistoricalData.Constituents != null)
            {
                UpdateStatResultCount(MyDataManager.HistoricalData.Constituents.Count());
            }
        }

        private void SetHistoricalDataFilter()
        {
            //Update Filter Drop Down list
            comboBoxStatFilter.Items.Clear();
            comboBoxStatFilter.Items.Add("");

            for(int i = 0; i <= HistoricalFilterKey.GetUpperBound(0); i++)
            {
                comboBoxStatFilter.Items.Add(HistoricalFilterKey[i,1]);
            }
        }

        private void SetLiveDataFilter()
        {
            comboBoxStatFilter.Items.Clear();
            comboBoxStatFilter.Items.Add("");

            for (int i = 0; i <= LiveFilterKey.GetUpperBound(0); i++)
            {
                comboBoxStatFilter.Items.Add(LiveFilterKey[i,1]);
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  tsBtnLoadHistorical_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void tsBtnLoadHistorical_Click(object sender, EventArgs e)
        {
            String folderName;

            dlgStatFolder = new FolderBrowserDialog();
            dlgStatFolder.Description = "Select folder containing historical data";
            dlgStatFolder.SelectedPath = Environment.CurrentDirectory;

            DialogResult result = dlgStatFolder.ShowDialog();

            if(result == DialogResult.OK)
            {
                folderName = dlgStatFolder.SelectedPath;
                MyDataManager.SetHistoricalDataPath(folderName);
                this.backgroundWorkerStat.RunWorkerAsync();
                this.backgroundWorkerProgress.RunWorkerAsync();
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  backgroundWorkerStat_DoWork
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void backgroundWorkerStat_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean success = MyDataManager.ReadHistoricalData();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  backgroundWorkerProgress_DoWork
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void backgroundWorkerProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int[] pct_progress = {0, 0};
            const long timeout = 10000;
            long time_passed = 0;
            int exit_persistence = 0;

            while(MyDataManager.HistoricalData.DownloadPercentage < 1 && time_passed < timeout)
            {
                System.Threading.Thread.Sleep(100);
                time_passed += 100;
                pct_progress[1] = (int)(MyDataManager.HistoricalData.DownloadPercentage * 100);
                if (pct_progress[1] == pct_progress[0])
                {
                    exit_persistence += 1;
                }
                else
                {
                    exit_persistence = 0;
                }

                //if the progress hasn't changed in 5 update periods, exit
                if (exit_persistence >= 5)
                {
                    break;
                }
                pct_progress[0] = pct_progress[1];
                worker.ReportProgress(pct_progress[1]);
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  backgroundWorkerProgress_ProgressChanged
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void backgroundWorkerProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressStats.Visible = true;
            progressStats.Value = e.ProgressPercentage;
            if(e.ProgressPercentage == 100)
            {
                progressStats.Visible = false;
                DisplayStatData();
                DisplayAnalysisData();
                SetDisplayHistoricalDataStatus(true);
                ClearFilter();
                UpdateAnalysisComboBox();
            }
        }

        /*****************************************************************************
         *  FUNCTION:       DisplayStatData
         *  Description:    Displays the loaded historical data on the Data Manager tab page.
         *  Parameters:     None
         *****************************************************************************/
        private void DisplayStatData()
        {
            tblStatTableMain.BindMarketData(MyDataManager.HistoricalData, true);
            UpdateStatResultCount(tblStatTableMain.DisplayedCount());

            if (this.tblStatTableMain.TableType == StatTableType.HIST_STATS)
            {
                SetHistoricalDataFilter();
            }
            else if (this.tblStatTableMain.TableType == StatTableType.LIVE_STATS)
            {
                SetLiveDataFilter();
            }
            else { }

            if (this.tabVisuals != null && tabControl1.TabPages.Contains(this.tabVisuals))
            {
                this.tabVisualsControl.ReBindExchangeMarket(MyDataManager.HistoricalData);
            }
        }

        /*****************************************************************************
         *  FUNCTION:       DisplayAnalysisData
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private void DisplayAnalysisData()
        {
            
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnExport_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (MyDataManager.HistoricalData != null)
            {
                MyDataManager.HistoricalData.ExportToXML();
            }
            else
            {
                const string message = "No Data has been loaded. Export Failed.";
                const string caption = "No Data";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
            }
        }

        /*****************************************************************************
         *  FUNCTION:       ShowVisualizationTab (overloaded)
         *  Description:    
         *  Parameters:     
         *          data_index   - 
         *          createNewTab - 
         *****************************************************************************/
        private void ShowVisualizationTab(int data_index, Boolean createNewTab)
        {
            List<int> pDataIndex = new List<int>();
            pDataIndex.Add(data_index);
            ShowVisualizationTab(pDataIndex, createNewTab);
        }

        /*****************************************************************************
         *  FUNCTION:       ShowVisualizationTab (overloaded)
         *  Description:    
         *  Parameters:     
         *          data_index   - 
         *          createNewTab - 
         *****************************************************************************/
        private void ShowVisualizationTab(List<int> data_index, Boolean createNewTab)
        {
            List<Equity> pEquities = new List<Equity>();
            int i;

            //Collect the equities to be displayed
            for (i = 0; i < data_index.Count; i++)
            {
                pEquities.Add(MyDataManager.HistoricalData.Constituents[data_index[i]]);
            }

            //Create new display instance if none exists
            if (tabVisuals == null)
            {
                tabVisuals = new TabPage();
                tabVisuals.Text = "Visualization";
                tabVisuals.Leave += new EventHandler(this.tabVisuals_OnLoseFocus);

                if (tabVisualsControl == null)
                {
                    tabVisualsControl = new VisualsTab(pEquities, MyDataManager.HistoricalData);
                    tabVisuals.Controls.Add(tabVisualsControl);
                    tabVisualsControl.Dock = DockStyle.Fill;
                }

                tabControl1.TabPages.Add(tabVisuals);
                tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
            }
            else if (!tabControl1.TabPages.Contains(tabVisuals))
            {
                tabVisualsControl.ReloadChart(pEquities);
                tabControl1.TabPages.Add(tabVisuals);
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabVisuals);
            }
            else if (createNewTab == false)
            {
                tabVisualsControl.AddToChart(pEquities);
            }
            
        }

        /*****************************************************************************
         *  EVENT HANDLER:  tabVisuals_OnLoseFocus
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void tabVisuals_OnLoseFocus(object sender, EventArgs e)
        {
            if(tabVisuals != null)
            {
                tabControl1.TabPages.Remove(tabVisuals);
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnExcelDowloader_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnExcelDowloader_Click(object sender, EventArgs e)
        {
            MyDataManager.RunHistoricalDataDownloader();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnShowChart_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnShowChart_OnClick(object sender, EventArgs e)
        {
            if(tblStatTableMain.SelectedEntries.Count > 0)
            {
                ShowVisualizationTab(tblStatTableMain.SelectedEntries, false);
            }
        }

        /*****************************************************************************
         *  FUNCTION:       WndProc (Windows Method)
         *  Description:    Intercepts all Windows messages directed at the MainForm window
         *  Parameters:     
         *          m   - 
         *****************************************************************************/
        protected override void WndProc(ref Message m)
        {
            Boolean createNewTab = false;
            if(m.LParam == tblStatTableMain.Handle)
            {
                createNewTab = true;
            }
            switch (m.Msg)
            {
                case (int)WM_CELLCLICK:
                    ShowVisualizationTab((int)m.WParam, createNewTab);
                    break;
                case (int)WM_MULTIROWCLICK:
                    ShowVisualizationTab(((StatTable)StatTable.FromHandle(m.LParam)).SelectedEntries, createNewTab);
                    break;
                case (int)WM_SHOWBTNCLICK:
                    if ((int)m.WParam == 0)
                        tabVisualsControl.ToggleCorrelationTable(false);
                    else
                        tabVisualsControl.ToggleCorrelationTable(true);
                    break;
                case (int)WM_PROCESS_TI:
                    tabVisualsControl.manageTechnicalIndicators();
                    break;
                case (int)WM_SHOWNEWWINDCLICK:
                    tabVisualsControl.displayNewWindow();
                    break;
                case (int)WM_LIVEUPDATE:
                    lblUpdate.Visible = false;
                    SetDisplayLiveDataStatus(true);
                    tblStatTableMain.TableType = StatTableType.LIVE_STATS;
                    DisplayStatData();
                    UpdateAnalysisComboBox();
                    break;
                case (int)WM_LIVESESSIONCLOSED:
                    SetDisplayLiveDataStatus(false);
                    break;
                case (int)WM_UPDATING_DATA:
                    lblUpdate.Visible = true;
                    break;
                case (int)WM_ADDWATCHLIST:
                    AddToWatchlist((int)m.WParam);
                    break;
                case (int)WM_MULTI_ADDWATCHLIST:
                    AddToWatchlist(((StatTable)StatTable.FromHandle(m.LParam)).SelectedEntries);
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        /*****************************************************************************
         *  FUNCTION:       AddToWatchlist
         *  Description:    
         *  Parameters:     
         *****************************************************************************/
        private void AddToWatchlist(int pIndex)
        {
            List<int> index_list = new List<int>();
            index_list.Add(pIndex);
            AddToWatchlist(index_list);
        }

        /*****************************************************************************
         *  FUNCTION:       AddToWatchlist
         *  Description:    
         *  Parameters:     
         *****************************************************************************/
        private void AddToWatchlist(List<int> pIndex)
        {
            foreach(int index in pIndex)
            {
                if(index >= 0 && index < MyDataManager.HistoricalData.Constituents.Count)
                {
                    this.watchlist1.Add(MyDataManager.HistoricalData.Constituents[index], MyDataManager.HistoricalData.Name);
                    this.MyDataManager.UserProfile.WatchlistItems.Add(MyDataManager.HistoricalData.Constituents[index]);
                }
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  statFilter_SelectionChanged
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void statFilter_SelectionChanged(object sender, EventArgs e)
        {
            switch(comboBoxStatFilter.SelectedIndex)
            {
                case 1:     //% Change Selected

                case 2:     //Avg. Price Selected
 
                case 3:     //Volatility Selected
                    tblStatTableMain.Invalidate();
                    groupBoxStatFilter.Visible = true;
                    break;

                default:
                    groupBoxStatFilter.Visible = false;
                    break;
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnRefreshStatTable_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnRefreshStatTable_Click(object sender, EventArgs e)
        {
            String[,] filterKey;
            String filterString = "";
            Boolean isValid = Helpers.ValidateNumeric(txtStatFrom.Text) && Helpers.ValidateNumeric(txtStatTo.Text);

            if (!(this.tblStatTableMain.TableType == StatTableType.LIVE_STATS && this.MyDataManager.IsLiveSessionOpen))
            {
                filterKey = this.HistoricalFilterKey;
            }
            else
            {
                filterKey = this.LiveFilterKey;
            }

            if (isValid)
            {
                if (txtStatFrom.Text != "")
                {
                    filterString += (filterKey[comboBoxStatFilter.SelectedIndex - 1, 0] + " >= " + txtStatFrom.Text);
                }
                if (txtStatTo.Text != "")
                {
                    if (filterString != "")
                    {
                        filterString += " And ";
                    }
                    filterString += (filterKey[comboBoxStatFilter.SelectedIndex - 1, 0] + " <= " + txtStatTo.Text); ;
                }
                tblStatTableMain.SetFilterExpression(this.toolStripContainer1.ContentPanel.Handle, filterString);
                tblStatTableMain.ApplyFilter();
                UpdateStatResultCount(tblStatTableMain.DisplayedCount());
            }
        }

        /*****************************************************************************
         *  FUNCTION:       UpdateStatResultCount
         *  Description:    
         *  Parameters:     
         *          resultCount   - 
         *****************************************************************************/
        private void UpdateStatResultCount(int resultCount)
        {
            lblStatResultNum.Text = resultCount.ToString() + " Results";
        }

        /*****************************************************************************
         *  FUNCTION:       UpdateAnalysisComboBox
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private void UpdateAnalysisComboBox()
        {
            if(MyDataManager.HistoricalData.Constituents != null &&
                MyDataManager.HistoricalData.Constituents.Count > 0)
            {
                this.analysisSelectBox.Items.Clear();
                foreach(Equity eq in MyDataManager.HistoricalData.Constituents)
                {
                    this.analysisSelectBox.Items.Add(eq.Name);
                }
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  analysisSelectBox_SelectedIndexChanged
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void analysisSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnAnalysisShowChart_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnAnalysisShowChart_Click(object sender, EventArgs e)
        {
            RunAnalysisAndDisplayChart();
        }

        /*****************************************************************************
         *  FUNCTION:       RunAnalysisAndDisplayChart
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private void RunAnalysisAndDisplayChart()
        {
            List<double> x_values = new List<double>();
            List<double> y_values = new List<double>();
            List<Equity> hist_data = new List<Equity>();
            //int i, x_index, y_index;
            //double data_value_x, data_value_y;

            if (MyDataManager.HistoricalData != null && 
                cbAnalysisIndicatorX.SelectedIndex >= 0 && 
                cbAnalysisIndicatorY.SelectedIndex >= 0 &&
                cbAnalysisType.SelectedIndex >= 0)
            {
                if (MyDataManager.HistoricalData.Constituents.Count > 0)
                {
                    hist_data = new List<Equity>(MyDataManager.HistoricalData.Constituents);
                    AnalysisChartTypeSpec(hist_data, (AnalysisChartType)cbAnalysisType.SelectedIndex, out x_values, out y_values);
                    AnalysisChartBindData(x_values, y_values);
                }
            }
        }

        /*****************************************************************************
         *  FUNCTION:       AnalysisChartTypeSpec
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private void AnalysisChartTypeSpec(List<Equity> hist_data, AnalysisChartType chart_type, out List<double> x_values, out List<double> y_values)
        {
            int i, x_index, y_index;
            double data_value_x, data_value_y;

            x_values = new List<double>();
            y_values = new List<double>();

            x_index = cbAnalysisIndicatorX.SelectedIndex;
            y_index = cbAnalysisIndicatorY.SelectedIndex;
            for (i = 0; i < hist_data.Count; i++)
            {
                data_value_x = 0;
                data_value_y = 0;
                switch (chart_type)
                {
                    case AnalysisChartType.AVERAGE:
                        data_value_x = AnalysisChartFeatureValue(hist_data[i], x_index, chart_type).Average();
                        data_value_y = AnalysisChartFeatureValue(hist_data[i], y_index, chart_type).Average();
                        this.panelAnalysis1.Visible = false;
                        break;
                    case AnalysisChartType.ANIMATED:
                        if (AnalysisDisplayIndex >= 0 && AnalysisDisplayIndex < hist_data.Count)
                        {
                            data_value_x = AnalysisChartFeatureValue(hist_data[i], x_index, chart_type)[AnalysisDisplayIndex];
                            data_value_y = AnalysisChartFeatureValue(hist_data[i], y_index, chart_type)[AnalysisDisplayIndex];
                            this.lblChartDate.Text = hist_data[0].HistoricalPriceDate[AnalysisDisplayIndex].ToShortDateString();
                            this.panelAnalysis1.Visible = true;
                        }
                        
                        break;
                    default:
                        break;
                }
                x_values.Add(data_value_x);
                y_values.Add(data_value_y);
            }
 
        }

        /*****************************************************************************
         *  FUNCTION:       AnalysisChartFeatureValue
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private List<double> AnalysisChartFeatureValue(Equity pInputData, int pFeatureIndex, AnalysisChartType pChartType)
        {
            List<double> temp_value = new List<double>();

            switch (pFeatureIndex)
            {
                //Daily Spread
                case 0:
                    temp_value = Helpers.ListDoubleOperation(ListOperator.DIFF, pInputData.HistoricalHighs, pInputData.HistoricalLows);
                    temp_value = Helpers.ListDoubleOperation(ListOperator.DIVIDE, temp_value, pInputData.HistoricalOpens);
                    temp_value = (new ListDouble(temp_value) * 100.0).ToList();
                    break;
                //Daily % Change
                case 1:
                    temp_value = (new ListDouble(pInputData.HistoricalPctChange)).ToList();
                    break;
                default:
                    break;
            }

            return temp_value;
        }

        /*****************************************************************************
         *  FUNCTION:       AnalysisChartBindData
         *  Description:    
         *  Parameters:     None
         *****************************************************************************/
        private void AnalysisChartBindData(List<double> x_values, List<double> y_values)
        {
            //Bind data to chart
            if (chartAnalysis.Series.Count <= 0)
            {
                chartAnalysis.Series.Add("Analysis");  
            }
            else if(chartAnalysis.Series.IndexOf("Analysis") < 0)
            {
                chartAnalysis.Series.Add("Analysis");  
            }
            chartAnalysis.Series["Analysis"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartAnalysis.Series["Analysis"].Points.Clear();
            chartAnalysis.Series["Analysis"].Points.DataBindXY(x_values, y_values);

            //Set chart axes labels
            chartAnalysis.ChartAreas[0].AxisX.Title = Analysis.ChartFeatures[cbAnalysisIndicatorX.SelectedIndex];
            chartAnalysis.ChartAreas[0].AxisY.Title = Analysis.ChartFeatures[cbAnalysisIndicatorY.SelectedIndex];

            chartAnalysis.Invalidate();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnChartNext_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnChartNext_Click(object sender, EventArgs e)
        {
            if (this.chartAnalysis.Series.Count > 0 &&
                this.AnalysisDisplayIndex < this.chartAnalysis.Series[0].Points.Count - 1)
            {
                 this.AnalysisDisplayIndex++;
                 RunAnalysisAndDisplayChart();
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnChartPrev_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnChartPrev_Click(object sender, EventArgs e)
        {
            if (this.chartAnalysis.Series.Count > 0 &&
                this.AnalysisDisplayIndex > 0)
            {
                this.AnalysisDisplayIndex--;
                RunAnalysisAndDisplayChart();
            }
        }

        private void tabAnalysis_Layout(object sender, LayoutEventArgs e)
        {
            //this.heatMap1.Redraw();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  analysis_nestedSplitPanelRightOnPaint
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void analysis_nestedSplitPanelRightOnPaint(object sender, PaintEventArgs e)
        {
            var control = sender as SplitContainer;
            //paint the three dots'
            Point[] points = new Point[3];
            var w = control.Width;
            var h = control.Height;
            var d = control.SplitterDistance;
            var sW = control.SplitterWidth;

            //calculate the position of the points'
            if (control.Orientation == Orientation.Horizontal)
            {
                points[0] = new Point((w / 2), d + (sW / 2));
                points[1] = new Point(points[0].X - 10, points[0].Y);
                points[2] = new Point(points[0].X + 10, points[0].Y);
            }
            else
            {
                points[0] = new Point(d + (sW / 2), (h / 2));
                points[1] = new Point(points[0].X, points[0].Y - 10);
                points[2] = new Point(points[0].X, points[0].Y + 10);
            }

            foreach (Point p in points)
            {
                p.Offset(-2, -2);
                e.Graphics.FillRectangle(SystemBrushes.ControlDark,
                    new Rectangle(p, new Size(4, 2)));

                p.Offset(1, 1);
                e.Graphics.FillRectangle(SystemBrushes.ControlLight,
                    new Rectangle(p, new Size(4, 2)));
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  btnLoadPatternForm_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void btnLoadPatternForm_Click(object sender, EventArgs e)
        {
            if (AlgDesignForm.IsDisposed || AlgDesignForm == null)
            {
                AlgDesignForm = new AlgorithmDesignForm(ref MyDataManager);
            }
            AlgDesignForm.Show(this);
        }

        /*****************************************************************************
         *  EVENT HANDLER:  random10ToolStripMenuItem_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void random10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            int[] indexList = new int[10];
            Random randGen = new Random();

            if (MyDataManager.HistoricalData != null && 
                MyDataManager.HistoricalData.Constituents.Count > 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    do
                    {
                        index = randGen.Next(MyDataManager.HistoricalData.Constituents.Count - 1);
                    }
                    while (indexList.Contains(index));

                    indexList[i] = index;
                }

                ShowVisualizationTab(indexList.ToList(), false);
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  cbRegionSelect_SelectedIndexChanged
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void cbRegionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> listOfMarkets;

            if(cbRegionSelect.SelectedIndex >= 0 && cbRegionSelect.SelectedIndex < RegionImageList.Length)
            {
                imgRegionFlag.Image = RegionImageList[cbRegionSelect.SelectedIndex];
            }

            listOfMarkets = MyDataManager.GetListOfAvailableMarkets(RegionDropDownList[cbRegionSelect.SelectedIndex]);
            this.cbMarketSelect.Items.Clear();
            this.cbMarketSelect.Items.AddRange(listOfMarkets.ToArray());

            toolStripStat.Focus();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  openToolStripMenuItem_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double dwnld_period;

            if(this.cbLiveDataInterval.SelectedIndex < 0)
            {
                dwnld_period = (double)this.LiveSessionIntervalsSec[0] / 60.0;
                this.cbLiveDataInterval.SelectedIndex = 0;
            }
            else
            {
                dwnld_period = (double)this.LiveSessionIntervalsSec[this.cbLiveDataInterval.SelectedIndex] / 60.0;
            }
            
            //Validate selected market

            //Start the download / periodic update
            MyDataManager.OpenLiveSession(dwnld_period);
        }

        /*****************************************************************************
         *  EVENT HANDLER:  openToolStripMenuItem_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDataManager.CloseLiveSession();
            SetDisplayLiveDataStatus(false);
        }

        /*****************************************************************************
         *  EVENT HANDLER:  cbMarket_IndexChanged
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void cbMarket_IndexChanged(object sender, EventArgs e)
        {
            int i, j;

            i = cbRegionSelect.SelectedIndex;
            j = cbMarketSelect.SelectedIndex;

            MyDataManager.ChangeActiveMarket(i, j);
            
            toolStripStat.Focus();
        }

        /*****************************************************************************
         *  EVENT HANDLER:  dataMenuArrow_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void dataMenuArrow_Click(object sender, EventArgs e)
        {
            if(this.DataMenuPanelVisible)
            {
                CollapseMenuPanel();
            }
            else
            {
                ExpandMenuPanel();
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  dataMenuArrow_MouseEnter
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void dataMenuArrow_MouseEnter(object sender, EventArgs e)
        {
            if (this.DataMenuPanelVisible)
            {
                this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_hover_rev;
            }
            else
            {
                this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_hover;
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  dataMenuArrow_MouseLeave
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void dataMenuArrow_MouseLeave(object sender, EventArgs e)
        {
            if (this.DataMenuPanelVisible)
            {
                this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_normal_rev;
            }
            else
            {
                this.dataMenuArrow.Image = MyMarketAnalyzer.Properties.Resources.arrow_icon_normal;
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  loadProfileToolStripMenuItem_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "MMA Profiles (*.mma)|*.mma";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = this.MyDataManager.UserProfile.CurrentLocation;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.MyDataManager.UpdateUserProfile(ofd.FileName);

                this.watchlist1.Visible = false;
                foreach (Equity eq in this.MyDataManager.UserProfile.WatchlistItems)
                {
                    this.watchlist1.Add(eq, eq.ListedMarket);
                }
                this.watchlist1.Visible = true;
            }
        }

        /*****************************************************************************
         *  EVENT HANDLER:  saveProfileToolStripMenuItem_Click
         *  Description:    
         *  Parameters:     
         *          sender - 
         *          e      -
         *****************************************************************************/
        private void saveProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "MMA Profiles (*.mma)|*.mma";
            sfd.FilterIndex = 1;
            sfd.InitialDirectory = this.MyDataManager.UserProfile.CurrentLocation;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.MyDataManager.UserProfile.Save(sfd.FileName);
            }
        }

        
        
    }
}
