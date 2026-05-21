using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice.UI
{
    partial class WindowViewModel : ReactiveObject
    {
        private int _windowWidth = 960;
        public int WindowWidth
        {
            get => this._windowWidth;
            set => this.RaiseAndSetIfChanged(ref this._windowWidth, value);
        }

        private int _windowHeight = 540;
        public int WindowHeight
        {
            get => this._windowHeight;
            set => this.RaiseAndSetIfChanged(ref this._windowHeight, value);
        }
    }
}
