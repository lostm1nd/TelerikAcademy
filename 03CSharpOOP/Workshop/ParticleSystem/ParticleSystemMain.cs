using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        static readonly Random RandomGenerator = new Random();

        static void Main()
        {
            var renderer = new ConsoleRenderer(20, 40);
            var particleOperator = new RepulsionParticleUpdater();
            var particles = new List<Particle>()
            {
                new ChaoticParticle(new MatrixCoords(10, 20), new MatrixCoords(0,0), RandomGenerator),
                //new ChickenParticle(new MatrixCoords(8, 18), new MatrixCoords(0,0), RandomGenerator),
                new Particle(new MatrixCoords(10, 4), new MatrixCoords(0,1)),
                new Particle(new MatrixCoords(10, 36), new MatrixCoords(0,-1)),
                new ParticleRepeller(new MatrixCoords(10,20), new MatrixCoords(0,0), 6),
                new ParticleRepeller(new MatrixCoords(10, 0), new MatrixCoords(0,0), 2),
                new ParticleRepeller(new MatrixCoords(10, 39), new MatrixCoords(0,0), 2)
            };

            Engine particleEngine = new Engine(renderer, particleOperator, particles, 500);
            particleEngine.Run();
        }
    }
}
