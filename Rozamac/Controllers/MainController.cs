using EasyModbus;
using Rozamac.Events;
using System;
using System.Collections.Generic;
using System.Timers;
using Yaskawa.PLCIInterface;

namespace Rozamac.Controllers
{
    public class MainController
    {
        StartEvent startEvent = new StartEvent();
        MainEvent mainEvent = new MainEvent();
        HomePageEvent homePageEvent = new HomePageEvent();
        LineSchemaEvent lineSchemaEvent = new LineSchemaEvent();

        private List<string> startList_ = new List<string>();
        private List<string> varList_ = new List<string>();
        private List<string> varList2_ = new List<string>();
        private List<string> LineSchemaList = new List<string>();

        private string _startPageVariables = "StartPageVariables";
        private string _mainTemplateVariables = "MainTemplateVariables";
        private string _homePageVariables = "HomePageVariables";
        private string _lineSchemaVariables = "LineSchemaVariables";

        private PLCIHandler _handler = new PLCIHandler();
        Timer timer = new Timer { AutoReset = true, Interval = 300 };

        public MainController()
        {
            timer.Elapsed += Do_Work;
            InitializeConnection();
        }

        private void Do_Work(object sender, ElapsedEventArgs e)
        {
            ReadStartPage();
            ReadMainTemplate();
            ReadHomePage();
            ReadLineSchema();
        }

        public bool InitializeConnection()
        {
            // clear out any previous connections
            _handler.DisconnectDispose();
            try
            {
                _handler.Connect("192.168.0.1");

                StartVarList();
                MainVarList();
                HomePageVarList();


                timer.Start();
                return true;
            }
            catch { timer.Stop(); return false; }
        }

        public void StartVarList()
        {
            startList_.Add("@GlobalVariables.gMakinaDrumWord");
            _handler.Subscribe(_startPageVariables, startList_);
        }

        public void ReadStartPage()
        {
            IList<object> variables = _handler.ReadVariableValues(_startPageVariables);
            startEvent.sendEventInfo(variables);
        }




        public void MainVarList()
        {
            varList_.Add("@GlobalVariables.gMakinaActualHiz");
            varList_.Add("@GlobalVariables.gAnaHizSetMdk");
            varList_.Add("@GlobalVariables.gOtomatikHiz");
            varList_.Add("@GlobalVariables.gMakinaDrumWord");
            _handler.Subscribe(_mainTemplateVariables, varList_);
        }

        public void ReadMainTemplate()
        {
            IList<object> variables = _handler.ReadVariableValues(_mainTemplateVariables);
            mainEvent.sendEventInfo(variables);
        }

        public void Write_gOtomatikGit(bool gOtomatikGitBool)
        {
            _handler.WriteVariableValue("@GlobalVariables.gOtomatikGit", gOtomatikGitBool);
        }




        public void HomePageVarList()
        {
            varList2_.Add("@GlobalVariables.gActualBaskiAdet");
            varList2_.Add("@GlobalVariables.gAdetSet");
            varList2_.Add("@GlobalVariables.gActualMetraj");
            varList2_.Add("@GlobalVariables.gMetrajSet");
            varList2_.Add("@GlobalVariables.gTunelIsiSet");
            varList2_.Add("@GlobalVariables.gTunelIsiActual");
            varList2_.Add("@GlobalVariables.gRenkIsiSet");
            varList2_.Add("@GlobalVariables.gRenkIsiActual");

            varList2_.Add("@GlobalVariables.gSarici1SetKg");
            varList2_.Add("@GlobalVariables.gSarici1ActKg");
            varList2_.Add("@GlobalVariables.gSarici2SetKg");
            varList2_.Add("@GlobalVariables.gSarici2ActKg");
            varList2_.Add("@GlobalVariables.gCozguSetKg");
            varList2_.Add("@GlobalVariables.gCozguActKg");
            varList2_.Add("@GlobalVariables.gCapSet");
            varList2_.Add("@GlobalVariables.gCozucuActCap");

            varList2_.Add("@GlobalVariables.SAxis1.Act.Torque");
            varList2_.Add("@GlobalVariables.SAxis2.Act.Torque");
            varList2_.Add("@GlobalVariables.SAxis3.Act.Torque");
            varList2_.Add("@GlobalVariables.SAxis4.Act.Torque");

            _handler.Subscribe(_homePageVariables, varList2_);
        }

        public void ReadHomePage()
        {
            IList<object> variables = _handler.ReadVariableValues(_homePageVariables);
            homePageEvent.sendEventInfo(variables);
        }

        public void Write_gAdetSet(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gAdetSet", value);
        }

        public void Write_gMetrajSet(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gMetrajSet", value);
        }

        public void Write_gMetrajReset(bool value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gMetrajReset", value);
        }

        public void Write_gFanStart(bool value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gFanStart", value);
        }

        public void Write_gTunelIsiSet(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gTunelIsiSet", value);
        }

        public void Write_gRenkIsiSet(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gRenkIsiSet", value);
        }

        public void Write_gSarici1SetKg(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gSarici1SetKg", value);
        }

        public void Write_gSarici1Enable(bool value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gSarici1Enable", value);
        }

        public void Write_gSarici2SetKg(int value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gSarici2SetKg", value);
        }

        public void Write_gSarici2Enable(bool value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gSarici2Enable", value);
        }

        public void Write_gCozguSetKg(int value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gCozguSetKg", value);
        }

        public void Write_gCapSet(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gCapSet", value);
        }

        public void Write_gSarici1Yon(bool value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gSarici1Yon", value);
        }

        public void Write_gMakinaCalismaModu(double value)
        {
            _handler.WriteVariableValue("@GlobalVariables.gMakinaCalismaModu", value);
        }






        public void LineSchemaVarList()
        {
            varList_.Add("@GlobalVariables.SAxis2.Act.Torque");
            _handler.Subscribe(_lineSchemaVariables, LineSchemaList);
        }

        public void ReadLineSchema()
        {
            IList<object> variables = _handler.ReadVariableValues(_lineSchemaVariables);
            lineSchemaEvent.sendEventInfo(variables);
        }
    }
}
