namespace MainScripts
{
    public class Stat
    {
        private string playerName;
        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                UIManager._.SetPlayerName();
            }
        }

        private int score;
        public int Score
        {
            get => score;
            set
            {
                score = value;
                UIManager._.SetScore();
            }
        }

        private int level;

        public int Level
        {
            get => level;
            set
            {
                level = value; 
                UIManager._.SetLevel();
            }
        }


        public readonly Game[] games;
        private static Stat _ins;

        public static Stat Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new Stat();
                return _ins;
            }
        }

        private Stat()
        {
            playerName = "فلان بن فلان";
            score = 0;
            level = 0;

            games = new[]
            {
                new Game("یگان مهندسی نیروی زمینی سپاه تهران", GameStyle.Question, new[]
                {
                    new DBQuestion(
                        new[]
                        {
                            "پس از وقوع سیل در استان سیستان و بلوچستان، کدام یک از انواع شبکه‌های زیر در بسیج منابع، نقش پررنگ‌تری خواهد داشت؟",
                            "شبکه‌های سازمانی", "شبکه‌های مجازی", "شبکه‌های دوستانه", "شبکۀ خانوادگی"
                        }, 2),
                    new DBQuestion(
                        new[]
                        {
                            "کدام یک از مهارت‌ها (شایستگی‌های) مدیریتی زیر، جهت مهار دشواری‌های حادثۀ سیل ضروری است؟",
                            "قاطعیت و ثبات رأی", "اقناع کنندگی", "مدیریت بحران توأم با توکل", "تحوّل‌خواهی انقلابی"
                        }, 3),
                    new DBQuestion(
                        new[]
                        {
                            "یک فرماندۀ ناحیه بسیج که در روزهای پس از سیل استان سیستان از ظرفیت شبکۀ خود در راستای کمک به حلّ بحران‌های ناشی از سیل بهره می‌گیرد، کدام یک از موارد ذیل را نمی‌تواند به شبکه بسپارد؟",
                            "بسترسازی پشتیبانی از شبکه", "رصد و پایش از طریق شبکه", "هماهنگی و برنامه ریزی در شبکه‌ها",
                            "تصمیم‌سازی و تصمیم‌گیری شبکه‌ای"
                        }, 4),
                    new DBQuestion(
                        new[]
                        {
                            "کدام یک از شایستگی‌های زیر در بسیج‌کنندگی نیروها در موقعیت سیل بروز بیشتری دارد؟",
                            "شجاعت", "آشنایی با روش‌های بوم‌شناسی", "بصیرت انقلابی", "محاسبه نفس"
                        }, 1),
                    new DBQuestion(
                        new[]
                        {
                            "آیا می‌توان از ظرفیت خواهران در مدیریت بحران سیل استان سیستان و بلوچستان استفاده کرد؟",
                            "به دلیل خطرناک بودن موقعیت امکان‌پذیر نیست.", "حتماً و باید از کمک خواهران استفاده کرد.",
                            "شاید در عمل چنین امری محقّق نشود.", "بهتر است این امر بر عهدۀ برادران باقی بماند."
                        }, 2),
                    new DBQuestion(
                        new[]
                        {
                            "کدام یک جزو نقش‌های مورد انتظار از یک فرماندۀ اعزام شده به استان سیستان و بلوچستان نیست؟",
                            "شبکه‌سازی", "رهبری نیروهای داوطلب", "فراخوانی عمومی", "تنویر افکار عمومی"
                        }, 4),
                    new DBQuestion(
                        new[]
                        {
                            "در صورتی که میان افسران، نیروهای داوطلب و افراد بومی، بر سر نحوۀ آذوقه‌رسانی به مناطق آسیب دیده از سیل اختلافی پیش بیاید، کدام یک از شایستگی‌های مورد نیاز فرمانده مدیریت موقعیت را برای او هموار می‌سازد؟",
                            "اصالت و نجابت خانوادگی", "قدرت بیان و اقناع کنندگی بلیغ",
                            "آشنایی با  شبکه‌های اجتماعی و مجازی", "توانمندی در به کارگیری رشد دهنده"
                        }, 2),
                    new DBQuestion(
                        new[]
                        {
                            "کمک به کنترل و حلّ مشکلات و بحران‌های اجتماعی مانند پیامدهای ناشی از بلایای طبیعی از جمله سیل استان سیستان نقش متناظر مورد انتظار کدام یک از صفات برجستۀ فرماندهان سپاه است؟",
                            "ظرفیت‌ساز", "روشنگر", "بسیج‌کننده", "مربّی"
                        }, 3),
                    new DBQuestion(
                        new[]
                        {
                            "با وجود تفاوت‌ها در زبان، گویش، فرهنگ و حتّی مذهب اهالی استان سیستان و بلوچستان، فرماندهان نواحی بسیج چگونه می‌توانند مدیریت بحران سیل را به دست گیرند؟",
                            "با به‌کارگیری مؤثّر خواهران در انجام مأموریت‌های سازمان.",
                            "با آشنایی با مباحث امنیتی و اطلاعاتی.", "با توانمندی در تدبیر و پیش‌بینی آینده.",
                            "ارتباط‌گیری و تعامل سازنده."
                        }, 4),
                    new DBQuestion(
                        new[]
                        {
                            "وظیفۀ فرماندهان نواحی و مناطق در استان‌های مجاور و حتّی غیرمجاور استان سیستان در خصوص سیل چیست؟",
                            "تبیین ناکارآمد‌ی‌های دستگاه‌های اجرایی",
                            "فراخوان‌های عمومی و ایجاد آمادگی‌های لازم در مخاطبین", "مطالعۀ چالش‌های زیست‌محیطی",
                            "درخواست اعزام به موقعیت مسأله"
                        }, 2)
                }),
                new Game("فلااااان", GameStyle.Type, null),
            };
        }

        public class DBQuestion
        {
            public string[] qa;
            public int answer;

            public DBQuestion(string[] q, int a)
            {
                qa = q;
                answer = a;
            }
        }

        public class Game
        {
            public GameStyle Style;
            //public readonly int QualifiedScore;
            public readonly DBQuestion[] DbQuestions;
            public bool Passed;
            public readonly string RoomName;
            public int tries;

            public Game(string name, GameStyle s, DBQuestion[] q)
            {
                Style = s;
                //QualifiedScore = minScore;
                DbQuestions = q;
                Passed = false;
                RoomName = name;
                tries = 0;
            }
        }

        public enum GameStyle
        {
            Question,
            SelectingPuzzle,
            ConnectingPuzzle,
            Type
        }
    }
}