using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.Google
{
    public class DiningPhilosophers
    {
        /*Five introspective and introverted philosophers are sitting at a circular
        table. In front of each philosopher is a plate of food. A fork (or a chopstick) lies
        between each philosopher, one by the philosopher’s left hand and one by the right
        hand. 
        - A philosopher cannot eat until he or she has forks in both hands. 
        - Forks are picked up one at a time. 
        - If a fork is unavailable, the philosopher simply waits for the fork to be freed. 
        - When a philosopher has two forks, he or she eats a few bites and then returns both forks to the table. 
        - If a philosopher cannot obtain both
        forks for a long time, he or she will starve. 
        Is there an algorithm that will ensure
        that no philosophers starve?
        */
        private int numberOfPhilosophers; // == number of forks
        private int availableForks;
        private Philosopher[] philosophers;
        private Fork[] forks;
        public DiningPhilosophers(int numberOfPhilosophers = 5)
        {
            this.numberOfPhilosophers = numberOfPhilosophers;
            this.availableForks = numberOfPhilosophers;
            philosophers = new Philosopher[numberOfPhilosophers];
            forks = new Fork[numberOfPhilosophers];
            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                forks[i] = new Fork();
            }
            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                // NAIVE: Can cause deadlocks since it's possible for all to pick the left fork, so none can eat.
                // Implementing timeout to wait time can cause livelock - because there's no guarantee the guy
                // who didn't get before can get now
                //philosophers[i] = new Philosopher(i, forks, i, (i+1) % numberOfPhilosophers);

                /*If you number each of the philosophers and forks counterclockwise around the table, then under the leftfork-frst strategy, each philosopher tries to pick up frst a lower numbered fork and then a higher
                numbered fork. This is true of every philosopher except for the last, who has fork n – 1 on the left
                and fork 0 on the right. Reversing the left-right order of acquisition for this philosopher means that
                all the philosophers acquire forks in the same order from a global perspective: lower number frst.
                
                
                 */
                //if (i == 0) //This solution avoids deadlocks but make phil-4 eat much more than phil-0

                if (i % 2 == 0) // forcing even-numbered phils to get odd-numbered forks first will improve fairness
                {
                    philosophers[i] = new Philosopher(i, forks, (i + 1) % numberOfPhilosophers, i);
                }
                else
                {
                    philosophers[i] = new Philosopher(i, forks, i, (i + 1) % numberOfPhilosophers);
                }
            }
        }

        public void StartEating()
        {
            var tasks = new Task[numberOfPhilosophers];
            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                tasks[i] = philosophers[i].Start();
            }
            Task.WaitAll(tasks);
        }
    }

    public class Philosopher
    {
        private Fork[] forks;
        private int fork1;
        private int fork2;
        public string Id { get; }
        public Philosopher(int id, Fork[] forks, int fork1, int fork2)
        {
            Id = "Phil-" + id;
            this.forks = forks;
            this.fork1 = fork1;
            this.fork2 = fork2;
            Console.WriteLine("{0}: Fork1 = {1}. Fork2 = {2}", Id, fork1, fork2);
        }
        public Task Start()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("{0}: Ready to eat using forks {1} and {2}", Id, fork1, fork2);
                while (true)
                {
                    lock (forks[fork1])
                    {
                        Console.WriteLine("{0}: Picking up fork {1}", Id, fork1);
                        forks[fork1].Pickup();
                        lock (forks[fork2])
                        {
                            Console.WriteLine("{0}: Picking up fork {1}", Id, fork2);
                            forks[fork2].Pickup();
                            Console.WriteLine("{0}: Eating", Id);
                        }
                    }
                }
            });
        }
    }


    public class Fork
    {
        private bool IsInUse;
        public void Pickup()
        {
            IsInUse = true;
        }
        public void Drop()
        {
            IsInUse = false;
        }
    }

}
