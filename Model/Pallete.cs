using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;

namespace Model {

    [Table("palletes")]
    public class Pallete : BaseContainer {
        private List<ICompactable> _containers = new();

        public Pallete() {
        }

        public Pallete(float length, float width, float height, float weight = 30) : base(length, width, height, weight) {
        }

        [NotMapped]
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

        [NotMapped]
        public float Weight {
            get {
                return _containers.Sum(
                    b => b.Weight) + _weight;
            }
        }

        [NotMapped]
        public List<ICompactable> Containers { get { return _containers; } }

        [NotMapped]
        public DateOnly SuitDate {
            get {
                if (_containers.Count > 0) {
                    return _containers.Min(b => b.SuitDate);
                }
                return DateOnly.MinValue;
            }
        }

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
            return string.Format($"{Id}" + "\t" + $"{Weight}" + "\t" + $"{Volume}" + "\t" + $"{SuitDate}");
        }
    }
}