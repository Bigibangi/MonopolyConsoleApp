namespace Model {

    public class Pallete : BaseContainer {
        private List<ICompactable> _containers = new();

        public Pallete(float length, float width, float height, float weight = 30) : base(length, width, height, weight) {
        }

        public float Volume {
            get {
                var v = _width * _height  * _depth;
                if (_containers.Count == 0)
                    return v;
                else {
                    return _containers.Sum
                        (b => b.Volume) + v;
                }
            }
            private set { }
        }

        public float Weight {
            get {
                return _containers.Sum(
                    b => b.Weight) + _weight;
            }
        }

        public DateOnly SuitDate => _containers.Min(b => b.SuitDate);

        public bool TryAddContainer<T>(BaseContainer container) where T : ICompactable {
            if (container.Width > _width || container.Depth > _depth) {
                return false;
            }
            AddContainer<T>(container);
            return true;
        }

        private void AddContainer<T>(BaseContainer container) where T : ICompactable {
            _containers.Add((ICompactable) container);
        }

        public override string ToString() {
            return string.Format($"{Id}" + " " + $"{Weight}" + " " + $"{SuitDate}");
        }
    }
}