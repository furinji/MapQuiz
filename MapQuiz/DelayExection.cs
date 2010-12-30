using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace MapQuiz
{
    public sealed class DelayExection
    {
        private DispatcherTimer _timer;
        private Action _exectAction;
        private Func<bool> _condition;

        public void Exect(Action exectAction, Func<bool> condition)
        {
            _exectAction = exectAction;
            _condition = condition;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_condition() == false) { return; }
            _exectAction();
            _timer.Stop();
        }

    }
}
