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
        MainEvent mainEvent = new MainEvent();
        HomePageEvent homePageEvent = new HomePageEvent();
        LineSchemaEvent lineSchemaEvent = new LineSchemaEvent();

        private List<string> varList_ = new List<string>();
        private List<string> varList2_ = new List<string>();
        private List<string> LineSchemaList = new List<string>();

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

                MainVarList();
                HomePageVarList();


                timer.Start();
                return true;
            }
            catch { timer.Stop(); return false; }
        }

        #region Main
        public void MainVarList()
        {
            varList_.Add("@GlobalVariables.SAxis2.Act.Torque");
            _handler.Subscribe(_mainTemplateVariables, varList_);
        }

        public void ReadMainTemplate()
        {
            IList<object> variables = _handler.ReadVariableValues(_mainTemplateVariables);
            mainEvent.sendEventInfo(variables);
        }

        #endregion

        #region HomePage

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
            varList2_.Add("@GlobalVariables.gCozguActCap");


            _handler.Subscribe(_homePageVariables, varList2_);
        }

        public void ReadHomePage()
        {
            IList<object> variables = _handler.ReadVariableValues(_homePageVariables);
            homePageEvent.sendEventInfo(variables);
        }

        #endregion

        #region LineSchema

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

        #endregion

        public void Write()
        {
            _handler.WriteVariableValue("@GlobalVariables.Deneme", 21.0f);
            //_handler.WriteVariableValue("@GlobalVariables.Denem1", true);
        }
    }
}
