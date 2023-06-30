using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model {

    public abstract class BaseContainer {
        protected uint _id;
        protected float _depth;
        protected float _width;
        protected float _height;
        protected float _weight;

        protected BaseContainer() {
        }

        protected BaseContainer(float depth, float width, float height, float weight) {
            _depth = depth;
            _width = width;
            _height = height;
            _weight = weight;
        }

        [Required]
        public uint Id => _id;

        [Required]
        [Column(TypeName = "depth")]
        public float Depth => _depth;

        [Required]
        [Column(TypeName = "width")]
        public float Width => _width;

        [Required]
        [Column(TypeName = "height")]
        public float Height => _height;
    }
}