using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _videoReopsitory;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoReopsitory = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object,_videoReopsitory.Object);

        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            _fileReader.Setup(fr=>fr.Read(It.IsAny<string>())).Returns("");
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        [Test]
        public void ReadVideoTitle_NonEmptyFile_ReturnsVideoName()
        {
            _fileReader.Setup(fr => fr.Read("Video.txt")).Returns( " {Id:1, Title:'Robot',IsProcessed:'True'}");
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Is.EqualTo("Robot"));
        }



        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosProcessed_ReturnsEmptyString()
        {
            _videoReopsitory.Setup(vr => vr.GetUnprocessedVideos())
                            .Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void GetUnprocessedVideoAsCsv_FewUnprocessedVideos_ReturnsStringWithIDofUnprocessedVideoInList()
        {
            _videoReopsitory.Setup(vr => vr.GetUnprocessedVideos())
                            .Returns(new List<Video> { 
                                new Video { Id=1},
                                new Video { Id=2}
                            });
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2"));
        }

    }
}
