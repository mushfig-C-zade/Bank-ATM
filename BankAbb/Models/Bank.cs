using BankATM.Exceptions;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using static BankATM.Utilities.Utilities;

namespace BankATM.Models
{
    public class Bank
    {
        private User[] Users = new User[]
         {
                new User {
                    FirstName = "Mushfig",
                    LastName = "Jahatzade",
                    Card = new ()
                    {
                        Pan="416973881231",
                        Pin="123",
                        Cvc="456",
                        ExpireDate = DateTimeOffset.UtcNow.AddYears(5),
                        Balans = new Random().Next(500 ,5000) / 100M
                    }
                },
                new User {
                    FirstName = "Elcin",
                    LastName = "Qasimov",
                    Card = new ()
                    {
                        Pan="416973881232",
                        Pin="124",
                        Cvc="457",
                        ExpireDate = DateTimeOffset.UtcNow.AddYears(5),
                        Balans = new Random().Next(500 ,5000) / 100M
                    }
                },
                new User {
                    FirstName = "Niyaz",
                    LastName = "Mammadov",
                    Card = new ()
                    {
                        Pan="416973881233",
                        Pin="125",
                        Cvc="458",
                        ExpireDate = DateTimeOffset.UtcNow.AddYears(5),
                        Balans = new Random().Next(500 ,5000) / 100M
                    }
                },
                new User {
                    FirstName = "Vuqar",
                    LastName = "Qarayev",
                    Card = new ()
                    {
                        Pan="416973881234",
                        Pin="126",
                        Cvc="459",
                        ExpireDate = DateTimeOffset.UtcNow.AddYears(5),
                        Balans = new Random().Next(500 ,5000) / 100M
                    }
                },
                new User {
                    FirstName = "Esqin",
                    LastName = "Hasanov",
                    Card = new ()
                    {
                        Pan="416973881234",
                        Pin="126",
                        Cvc="459",
                        ExpireDate = DateTimeOffset.UtcNow.AddYears(5),
                        Balans = new Random().Next(500 ,5000) / 100M
                    }
                },

         };

        public void AddHistoryToUser(User user, string operation)
        {
            History[] tmp = new History[user.Histories == null ? 1 : user.Histories.Length + 1];

            if (user.Histories is not null)
            {
                for (int i = 0; i < user.Histories.Length; i++)
                {
                    tmp[i] = user.Histories[i];
                }
            }

            tmp[^1] = new(operation);

            user.Histories = tmp;
        }

        public User? Login(string pin)
        {
            if (string.IsNullOrWhiteSpace(pin))
                throw new ArgumentException("IsNullOrWhiteSpace");

            foreach (var user in Users)
            {
                if (user.Card.Pin == pin)
                    return user;
            }

            throw new UserNotFoundException();
        }

        public bool CheckPan(string pan)
        {
            if (string.IsNullOrWhiteSpace(pan))
                throw new ArgumentException("IsNullOrWhiteSpace");

            foreach (var user in Users)
            {
                if (user.Card.Pan == pan)
                    return true;
            }

            return false;
        }

        public User? CheckExistence(string pan)
        {
            if (string.IsNullOrWhiteSpace(pan))
                throw new ArgumentException("IsNullOrWhiteSpace");

            foreach (var user in Users)
            {
                if (user.Card.Pan == pan)
                    return user;
            }

            throw new UserNotFoundException();
        }


        public decimal Balans(User user) => user.Card.Balans;

        public void GetMoneyFromBalance(Card card, decimal money)
        {
            if (card.Balans < money)
                throw new BalanceOutOfRangeException($"More than {money}");

            card.Balans -= money;
        }

        public User? GetUserByPan(string pan)
        {
            if (!CheckPan(pan))
                throw new PanNotFoundException();

            foreach (var user in Users)
            {
                if (user.Card.Pan == pan)
                    return user;
            }

            return null;
        }

        public void CardToCard(string fromCardPan, string toCardPan, decimal money)
        {
            User? fromUser = GetUserByPan(fromCardPan),
                    toUser = GetUserByPan(toCardPan);

            if (fromUser is null)
                throw new UserNotFoundException("From isn't found");
            else if (toUser is null)
                throw new UserNotFoundException("ToUser isn't found");

            GetMoneyFromBalance(fromUser.Card, money);
            toUser.Card.Balans += money;
        }

        public void ShowAllUserHistory(User user)
        {
            foreach (var item in user.Histories)
            {
                Console.WriteLine($"{item.DateTime} - {item.Operation}");
            }
        }

        public void Menu(User user)
        {
            int idx = 0;
            char[] arr = { '>', ' ', ' ', ' ' };

            Console.WriteLine("Xos gelmisiniz, {0}", user);

            Thread.Sleep(1000);

            do
            {

                Console.Clear();
                Console.WriteLine("Asagidakilardan birini secin");
                Console.WriteLine($"{arr[0]} Balans");
                Console.WriteLine($"{arr[1]} Nagd Pul");
                Console.WriteLine($"{arr[2]} Card to Card");
                Console.WriteLine($"{arr[3]} History");

                var keyInfo = Console.ReadKey();


                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (idx < 3)
                        Swap(ref arr[idx], ref arr[++idx]);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (idx > 0)
                        Swap(ref arr[idx], ref arr[--idx]);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (idx)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine($"Balans: {Balans(user)}");
                            break;
                        case 1:
                            int idx1 = 0;
                            char[] arr1 = { '>', ' ', ' ', ' ', ' ' };

                            do
                            {
                                Console.WriteLine("Secim edin");
                                Console.WriteLine($"{arr1[0]} 10 AZN");
                                Console.WriteLine($"{arr1[1]} 20 AZN");
                                Console.WriteLine($"{arr1[2]} 50 AZN");
                                Console.WriteLine($"{arr1[3]} 100 AZN");
                                Console.WriteLine($"{arr1[4]} Diger");

                                var keyInfo1 = Console.ReadKey();
                                Console.Clear();
                                if (keyInfo1.Key == ConsoleKey.DownArrow)
                                {
                                    if (idx1 < 4)
                                        Swap(ref arr1[idx1], ref arr1[++idx1]);
                                }
                                else if (keyInfo1.Key == ConsoleKey.UpArrow)
                                {
                                    if (idx1 > 0)
                                        Swap(ref arr1[idx1], ref arr1[--idx1]);
                                }
                                else if (keyInfo1.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();

                                    try
                                    {
                                        if (idx1 == 0)
                                        {
                                            GetMoneyFromBalance(user.Card, 10);



                                            AddHistoryToUser(user, BankMessages.Deducted10AZNFromBalance);

                                            return;
                                        }
                                        else if (idx1 == 1)
                                        {
                                            GetMoneyFromBalance(user.Card, 20);

                                            AddHistoryToUser(user, BankMessages.Deducted20AZNFromBalance);
                                            return;
                                        }
                                        else if (idx1 == 2)
                                        {
                                            GetMoneyFromBalance(user.Card, 50);

                                            AddHistoryToUser(user, BankMessages.Deducted50AZNFromBalance);
                                            return;
                                        }
                                        else if (idx1 == 3)
                                        {
                                            GetMoneyFromBalance(user.Card, 100);

                                            AddHistoryToUser(user, BankMessages.Deducted100AZNFromBalance);
                                            return;
                                        }
                                        else if (idx1 == 4)
                                        {
                                            Console.WriteLine("Cixarmaq istediyiniz meblegi daxil edin");
                                            decimal money = decimal.Parse(Console.ReadLine());
                                            GetMoneyFromBalance(user.Card, money);

                                            AddHistoryToUser(user, BankMessages.DeductedEnteredAZNFromBalance(money));
                                            return;
                                        }
                                    }

                                    catch (BalanceOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            } while (true);
                            break;
                        case 2:
                            Console.WriteLine("Hansi karta kocurme etmek isteyirsiz pan daxil edin");

                            string fromUserPan = user.Card.Pan,
                                toUserPan = Console.ReadLine();

                            try
                            {
                                Console.WriteLine("Meblegi daxil edin");
                                decimal money = decimal.Parse(Console.ReadLine());
                                CardToCard(fromUserPan, toUserPan, money);
                                Console.WriteLine("{0} megleg  gonderildi", money);
                                Thread.Sleep(3000);
                            }
                            catch (UserNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (BalanceOutOfRangeException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (PanNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 3:
                            Console.Clear();

                            ShowAllUserHistory(user);

                            Thread.Sleep(6000);
                            break;
                    }
                }
            } while (true);
        }

    }
}
