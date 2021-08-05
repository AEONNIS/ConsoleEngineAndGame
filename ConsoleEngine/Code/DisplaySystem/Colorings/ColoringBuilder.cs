using System;

namespace ConsoleEngine.DisplaySystem
{
    public class ColoringBuilder
    {
        #region Fields
        private bool _foreground = true;
        private ConsoleColor _bgColor = ConsoleColor.Black;
        private ConsoleColor _fgColor = ConsoleColor.Gray;
        #endregion

        #region Properties
        public ColoringBuilder Black
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Black;
                return this;
            }
        }

        public ColoringBuilder DarkBlue
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkBlue;
                return this;
            }
        }

        public ColoringBuilder DarkGreen
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkGreen;
                return this;
            }
        }

        public ColoringBuilder DarkCyan
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkCyan;
                return this;
            }
        }

        public ColoringBuilder DarkRed
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkRed;
                return this;
            }
        }

        public ColoringBuilder DarkMagenta
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkMagenta;
                return this;
            }
        }

        public ColoringBuilder DarkYellow
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkYellow;
                return this;
            }
        }

        public ColoringBuilder Gray
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Gray;
                return this;
            }
        }

        public ColoringBuilder DarkGray
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.DarkGray;
                return this;
            }
        }

        public ColoringBuilder Blue
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Blue;
                return this;
            }
        }

        public ColoringBuilder Green
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Green;
                return this;
            }
        }

        public ColoringBuilder Cyan
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Cyan;
                return this;
            }
        }

        public ColoringBuilder Red
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Red;
                return this;
            }
        }

        public ColoringBuilder Magenta
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Magenta;
                return this;
            }
        }

        public ColoringBuilder Yellow
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.Yellow;
                return this;
            }
        }

        public ColoringBuilder White
        {
            get
            {
                GetColor(_foreground) = ConsoleColor.White;
                return this;
            }
        }

        public ColoringBuilder On
        {
            get
            {
                _foreground = false;
                return this;
            }
        }
        #endregion

        #region Methods
        public Coloring Build()
        {
            var coloring = new Coloring { BgColor = _bgColor, FgColor = _fgColor };
            Reset();

            return coloring;
        }
        #endregion

        #region PrivateMethods
        private ref ConsoleColor GetColor(bool foreground) => ref foreground ? ref _fgColor : ref _bgColor;

        private void Reset()
        {
            _foreground = true;
            _bgColor = ConsoleColor.Black;
            _fgColor = ConsoleColor.Gray;
        }
        #endregion
    }
}
