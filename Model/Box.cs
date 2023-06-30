using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model {

    [Table("boxes")]
    public class Box : BaseContainer, ICompactable {
        private DateOnly _prodDate;
        private DateOnly _suitDate;

        public Box() { }
        public Box(float depth,
                   float width,
                   float height,
                   float weight,
                   DateOnly date) : base(depth, width, height, weight) {
            SetDate(date);
        }

        public Box(float depth,
                   float width,
                   float height,
                   float weight,
                   DateOnly prodDate,
                   DateOnly suitDate) : base(depth, width, height, weight) {
            _prodDate = prodDate;
            _suitDate = suitDate;
        }

        private void SetDate(DateOnly date) {
            if (date < DateOnly.FromDateTime(DateTime.Now)) {
                _prodDate = date;
            }
            else {
                _suitDate = date;
            }
        }

        [Column("produced")]
        public DateOnly ProdDate => _prodDate;

        [Column("suitdate")]
        [Required]
        public DateOnly SuitDate {
            get {
                if (_prodDate.Year > -1) {
                    return _prodDate.AddDays(100);
                }
                return _suitDate;
            }
            set {
                if (value < _prodDate) {
                    _suitDate = _prodDate;
                    /*
                     * throw new Exception("продукт просрочен")
                     */
                }
                else
                    _suitDate = value;
            }
        }

        [Required]
        [Column("weight")]
        public float Weight => _weight;

        public float Volume => _width * _depth * _height;
    }
}