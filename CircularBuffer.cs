using System.Collections;

namespace DataStructures
{
    public class CircularBuffer
    {
        //Why use _ as a variable prefix?
        //It differentiates between local and instance variables.
        private double[] _buffer;
        private int _start;
        private int _end;

        //Sets the overloaded constructor with a default capacity of 10.
        public CircularBuffer() : this(capacity:10)
        {
        }

        public CircularBuffer(int capacity)
        {
            _buffer = new double[capacity+1];
            _start = 0;
            _end = 0;
        }

        public void Write(double value)
        {
            _buffer[_end] = value;
            _end = (_end + 1) % _buffer.Length;
            if (_end == _start)
            {
                _start = (_start + 1) % _buffer.Length;
            }
        }

        public double Read()
        {
            var result = _buffer[_start];
            _start = (_start + 1) % _buffer.Length;
            return result;
        }

        public int Capacity 
        { 
            get { return _buffer.Length; } 
        }

        public bool IsEmpty 
        {
            get { return _end == _start; }
        }

        public bool IsFull 
        {
            get { return (_end + 1) % _buffer.Length == _start;  }
        }  
    }
}