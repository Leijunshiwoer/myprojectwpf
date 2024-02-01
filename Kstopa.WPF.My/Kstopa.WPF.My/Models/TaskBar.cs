using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.WPF.My.Models
{
    public class TaskBar: BindableBase
    {
        /// <summary>
		/// 图标
		/// </summary>
		private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        /// <summary>
        /// 出发目标
        /// </summary>
        private string target;

        public string Target
        {
            get { return target; }
            set { target = value; }
        }

    }
}
