using System.Collections.Generic;

namespace FirstPersonView
{
    public class FPV_Collection<T>
    {
        /// <summary>
        /// Container of this collection
        /// </summary>
        private HashSet<T> _container;

        /// <summary>
        /// Enumerator of this collection. this is used to prevent garbage.
        /// </summary>
        private IEnumerator<T> _enumerator;

        /// <summary>
        /// Constructor
        /// </summary>
        public FPV_Collection()
        {
            _container = new HashSet<T>();
            UpdateEnumerator();
        }

        /// <summary>
        /// Update the containers Enumerator.
        /// </summary>
        private void UpdateEnumerator()
        {
            _enumerator = _container.GetEnumerator();
        }

        /// <summary>
        /// Get the enumerator of this collection. This will not allocate garbage.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator;
        }

        /// <summary>
        /// Add a new item to the collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            _container.Add(item);
            UpdateEnumerator();
        }

        /// <summary>
        /// Remove an item from the collection
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            _container.Remove(item);
            UpdateEnumerator();
        }

        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
        {
            _container.Clear();
            UpdateEnumerator();
        }

    }
}
