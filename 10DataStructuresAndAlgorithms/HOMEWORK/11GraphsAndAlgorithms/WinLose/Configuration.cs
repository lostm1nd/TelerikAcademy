namespace WinLose
{
    struct Configuration
    {
        public Configuration(string configuration, int wave) : this()
        {
            this.InitializeConfiguration(configuration);
            this.Wave = wave;
        }

        public int FirstDigit { get; set; }

        public int SecondDigit { get; set; }

        public int ThirdDigit { get; set; }

        public int ForthDigit { get; set; }

        public int FifthDigit { get; set; }

        public int Wave { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}",
                this.FirstDigit, this.SecondDigit, this.ThirdDigit, this.ForthDigit, this.FifthDigit);
        }

        public void Modify(int number, bool perfomAddition)
        {
            int modifier = 1;
            if (!perfomAddition)
            {
                modifier = 1;
            }

            switch (number)
            {
                case 1:
                    this.FirstDigit = this.FirstDigit + modifier;
                    break;
                case 10:
                    this.SecondDigit = this.SecondDigit + modifier;
                    break;
                case 100:
                    this.ThirdDigit = this.ThirdDigit + modifier;
                    break;
                case 1000:
                    this.ForthDigit = this.ForthDigit + modifier;
                    break;
                case 10000:
                    this.FifthDigit = this.FifthDigit + modifier;
                    break;
                default:
                    break;
            }

            this.NormalizeFields();
        }

        private void NormalizeFields()
        {
            if (this.FirstDigit > 9)
            {
                this.FirstDigit = 0;
            }

            if (this.FirstDigit < 0)
            {
                this.FirstDigit = 9;
            }

            if (this.SecondDigit > 9)
            {
                this.SecondDigit = 0;
            }

            if (this.SecondDigit < 0)
            {
                this.SecondDigit = 9;
            }

            if (this.ThirdDigit > 9)
            {
                this.ThirdDigit = 0;
            }

            if (this.ThirdDigit < 0)
            {
                this.ThirdDigit = 9;
            }

            if (this.ForthDigit > 9)
            {
                this.ForthDigit = 0;
            }

            if (this.ForthDigit < 0)
            {
                this.ForthDigit = 9;
            }

            if (this.FifthDigit > 9)
            {
                this.FifthDigit = 0;
            }

            if (this.FifthDigit < 0)
            {
                this.FifthDigit = 9;
            }
        }

        private void InitializeConfiguration(string configuration)
        {
            this.FirstDigit = configuration[0] - '0';
            this.SecondDigit = configuration[1] - '0';
            this.ThirdDigit = configuration[2] - '0';
            this.ForthDigit = configuration[3] - '0';
            this.FifthDigit = configuration[4] - '0';
        }
    }
}