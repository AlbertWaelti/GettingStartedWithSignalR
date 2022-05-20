using System;

namespace WiredBrain.Helpers
{
    public class OrderChecker
    {
        private readonly Random _random;
        private int _index;

        private readonly string[] Status =
            {"Grinding beans", "Steaming milk", "Taking a sip (quality control)", "On transit to counter", "Picked up"};

        public OrderChecker(Random random)
        {
            this._random = random;
        }

        public CheckResult GetUpdate(int orderNo)
        {
            if (_random.Next(1, 5) == 4)
            {
                if (Status.Length -1 > _index)
                {
                    _index++;
                    var result = new CheckResult
                    {
                        New = true,
                        Update = Status[_index],
                        Finished = Status.Length - 1 == _index
                    };
                    if (result.Finished)
                        _index = 0;
                    return result;
                }
            }

            return new CheckResult {New = false};
        }
    }

    public class CheckResult
    {
        public bool New { get; set; }
        public string Update { get; set; }
        public bool Finished { get; set; }
    }
}
