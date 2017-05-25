using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preps.OOAD.ElevatorDesign
{
    public enum State
    {
        Stationary, Running, OutOfService
    }

    public enum Direction
    {
        GoingUp, GoingDown
    }

    public class Elevator
    {
        private readonly int _lowestFloor;
        private readonly int _highestFloor;
        private readonly HashSet<int> _requestedStops;
        private int _currentFloor;
        public int CurrentFloor
        {
            get { return _currentFloor; }
            set
            {
                if (value >= _lowestFloor && value <= _highestFloor)
                {
                    _currentFloor = value;
                }
            }
        }
        public State State { get; set; }
        public Direction Direction { get; set; }
        public Elevator(int lowestFloor, int highestFloor)
        {
            _lowestFloor = lowestFloor;
            _highestFloor = highestFloor;
            _requestedStops = new HashSet<int>();
        }

        public void RequestStop(ButtonInside destination)
        {
            if (_requestedStops.Add(destination.StopNumber))
            {
                // What else? Notification, etc?
            }
        }

        public void Move()
        {
            if (State != State.OutOfService)
            {
                while (_requestedStops.Count > 0)
                {

                }
            }
        }

        public void MakeAStop()
        {
            // Stop
            // Open door
            // Close door
            // Continue moving
        }
    }

    public class ButtonInside : Button
    {
        private Elevator _elevator;
        public readonly int StopNumber;
        public ButtonInside(Elevator elevator, int stopNumber)
        {
            _elevator = elevator;
            StopNumber = stopNumber;
        }
        public override void Trigger()
        {
            _elevator.RequestStop(this);
        }
    }

    public abstract class Button
    {
        protected bool IsButtonLightOn { get; set; }
        public abstract void Trigger();
        public virtual void ToggleIllumination()
        {
            IsButtonLightOn = !IsButtonLightOn;
        }
    }
    /* 
     * USE CASES:
     *  User
     *      - Press Up or Down button from a floor
     *      - Press Floor (destination) button from inside the elevator
     *      
     *  Elevator
     *      - Go up or Down
     *      - Open or close door
     *      
     *  Elevator Controller
     *      - Track all elevators in the building
     *      
     * QUESTIONS
     *  How many elevators in the building?
     *  Will elevators manage their own queues or will the queues be handled centrally?
     */
}
