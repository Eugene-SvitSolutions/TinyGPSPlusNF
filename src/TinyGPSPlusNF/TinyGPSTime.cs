﻿namespace TinyGPSPlusNF
{
    public class TinyGPSTime : TinyGPSData
    {
        private int _time;
        private int _newTime;

        /// <summary>
        /// Raw time in HHMMSSCC format.
        /// </summary>
        public int Value
        {
            get
            {
                this._updated = false;
                return this._time;
            }
        }

        /// <summary>
        /// Hour (0-23).
        /// </summary>
        public int Hour
        {
            get
            {
                this._updated = false;
                return this._time / 1000000;
            }
        }

        /// <summary>
        /// Minute (0-59).
        /// </summary>
        public int Minute
        {
            get
            {
                this._updated = false;
                return (this._time / 10000) % 100;
            }
        }

        /// <summary>
        /// Second (0-59).
        /// </summary>
        public int Second
        {
            get
            {
                this._updated = false;
                return (this._time / 100) % 100;
            }
        }

        /// <summary>
        /// 100ths of a second (0-99).
        /// </summary>
        public int Centisecond
        {
            get
            {
                this._updated = false;
                return this._time % 100;
            }
        }

        public TinyGPSTime()
        {
            this._valid = false;
            this._updated = false;
            this._time = 0;
        }

        internal override void OnCommit()
        {
            this._time = this._newTime;
        }

        internal override void Set(string term)
        {
            if (TryParse.Double(term, out double d))
            {
                this._newTime = (int)(100 * d);
                this._isOkToCommit = true;
            }
            else
            {
                this._isOkToCommit = false;
            }
        }
    }
}