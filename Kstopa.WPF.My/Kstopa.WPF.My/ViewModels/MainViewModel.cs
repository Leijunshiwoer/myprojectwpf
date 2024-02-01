using Kstopa.WPF.My.Extensions;
using Kstopa.WPF.My.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Kstopa.WPF.My.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
       
        private IRegionNavigationJournal journal;
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager= regionManager;
            menuBars = new ObservableCollection<MenuBar>();//新建菜单集合对象
            CreateMenuBar();//初始化菜单

        }

        #region 属性
        private ObservableCollection<MenuBar> menuBars;
        /// <summary>
        /// 菜单集合
        /// </summary>
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        #endregion



        #region 命令
        /// <summary>
        /// 关闭程序
        /// </summary>
        private DelegateCommand _CloseCmd;
        public DelegateCommand CloseCmd =>
            _CloseCmd ?? (_CloseCmd = new DelegateCommand(ExecuteCloseCmd));

        void ExecuteCloseCmd()
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }


        /// <summary>
        ///  向前导航
        /// </summary>
        private DelegateCommand _MovePrevCommand;
        public DelegateCommand MovePrevCommand =>
            _MovePrevCommand ?? (_MovePrevCommand = new DelegateCommand(ExecuteMovePrevCommand));

        void ExecuteMovePrevCommand()
        {
            if (journal != null && journal.CanGoBack)
            {
                journal.GoBack();
            }

        }

        private DelegateCommand _MoveNextCommand;
        public DelegateCommand MoveNextCommand =>
          _MoveNextCommand ?? (_MoveNextCommand = new DelegateCommand(ExecuteMoveNextCommand));

        void ExecuteMoveNextCommand()
        {
            if (journal != null && journal.CanGoForward)
            {
                journal.GoForward();
            }

        }

        private DelegateCommand<MenuBar> _NavigateCommand;
        public DelegateCommand<MenuBar> NavigateCommand =>
            _NavigateCommand ?? (_NavigateCommand = new DelegateCommand<MenuBar>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });

        }
        #endregion


        #region 私有方法



        private void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "代办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }
        #endregion
    }
}
