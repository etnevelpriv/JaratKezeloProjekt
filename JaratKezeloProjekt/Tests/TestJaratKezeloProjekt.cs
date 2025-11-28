using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace JaratKezeloProjekt.Tests
{
    [TestFixture]
    internal class TestJaratKezeloProjekt
    {

        [Test]
        public void ErvenyesUjJarat()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            var jaratok = kezelo.JaratokRepuloterrol("Budapest");
            Assert.That(jaratok, Has.Count.EqualTo(1));
            Assert.That(jaratok[0], Is.EqualTo("JARAT-12345"));
        }
        [Test]
        public void ErvenytelenyUjJarat()
        {
            JaratKezelo jaratok = new JaratKezelo();
            jaratok.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            Assert.Throws<ArgumentException>(() => jaratok.UjJarat("JARAT-12345", "Bukarest", "Berlin", new DateTime(2025, 12, 3, 15, 40, 0)));
        }
        [Test]
        public void ErvenyesKeses()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            kezelo.Keses("JARAT-12345", 30);
            var indulas = kezelo.MikorIndul("JARAT-12345");
            Assert.That(indulas, Is.EqualTo(new DateTime(2025, 12, 3, 16, 10, 0)));
        }
        [Test]
        public void ErvenytelenKeses()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            Assert.Throws<ArgumentException>(() => kezelo.Keses("JARAT-12345", -15));
        }
        [Test]
        public void ErvenyesMikorIndul()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            var indulas = kezelo.MikorIndul("JARAT-12345");
            Assert.That(indulas, Is.EqualTo(new DateTime(2025, 12, 3, 15, 40, 0)));
        }
        [Test]
        public void ErvenytelenMikorIndul()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            Assert.Throws<ArgumentException>(() => kezelo.MikorIndul("JARAT-54321"));
        }
        [Test]
        public void ErvenyesJaratokRepuloterrol()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            var jaratok = kezelo.JaratokRepuloterrol("Budapest");
            Assert.That(jaratok[0], Is.EqualTo("JARAT-12345"));
        }
        [Test]
        public void ErvenytelenJaratokRepuloterrol()
        {
            var kezelo = new JaratKezelo();
            kezelo.UjJarat("JARAT-12345", "Budapest", "Moszkva", new DateTime(2025, 12, 3, 15, 40, 0));
            Assert.Throws<ArgumentException>(() => kezelo.JaratokRepuloterrol("London"));
        }
    }
}
