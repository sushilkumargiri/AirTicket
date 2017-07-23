using AirTicket.BL;
using AirTicket.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.Tests.Business
{
	[TestClass]
    public class FileReadWriteTest
    {
        [TestMethod]
        public void Read_Xml_Files()
        {
            //init
            var xmlList = new List<string>() { "Xml Data 1", "Xml Data 2", "Xml Data 3" };

            //Setup
            var mockRepository = new Mock<IFileReadRepository>();
            mockRepository.Setup(m => m.ReadXmlFile()).Returns(xmlList);
            var fileReadService = new FileReadService(mockRepository.Object);

            //act
            var returnedXML = fileReadService.ReadXmlFile();

            //assert
            Assert.AreEqual(returnedXML.Count(), 3);
        }
        [TestMethod]
        public void Read_Xslt_File()
        {
            //init
            var xsltStr = "Xslt string";

            //Setup
            var mockRepository = new Mock<IFileReadRepository>();
            mockRepository.Setup(m => m.ReadXsltFile()).Returns(xsltStr);
            var fileReadService = new FileReadService(mockRepository.Object);

            //act
            var returnedXML = fileReadService.ReadXsltFile();

            //assert
            Assert.AreEqual(xsltStr, "Xslt string");
        }

        [TestMethod]
        public void Write_Html_File()
        {
            //init
            var xsltStr = "Html string";
            var fileName = "test.html";

            //Setup
            var mockRepository = new Mock<IFileWriteRepository>();
            mockRepository.Setup(m => m.WriteHtmlFile(xsltStr,fileName)).Returns(true);
            var fileWriteService = new FileWriteService(mockRepository.Object);

            //act
            var status = fileWriteService.WriteHtmlFile(xsltStr, fileName);

            //assert
            Assert.AreEqual(status, true);
        }
        [TestMethod]
		public void Transform_Xml_and_Xslt_to_Html()
        {
			//init
            var xmlString = "<?xml version=\"1.0\" standalone=\"yes\"?><Overview><Assigned><AssignedCount>1</AssignedCount></Assigned></Overview>";
            var xsltString = "<?xml version=\"1.0\" encoding=\"utf - 8\" ?><!DOCTYPE xsl:stylesheet [<!ENTITY nbsp \" &#160;\">]><xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:output method=\"html\"/><xsl:template match=\"/\"><HTML>"
            + "<xsl:if test=\"Overview / Assigned / AssignedCount != '0'\">Yes</xsl:if><xsl:if test=\"Overview / Assigned / AssignedCount = '0'\">No</xsl:if>"
				+ "</HTML></xsl:template></xsl:stylesheet>";
            var output = "<HTML>Yes</HTML>";

            //Setup
            var mock = new Mock<IFileTransformService>();
            mock.Setup(m => m.TransformXMLToHTML(xmlString, xsltString)).Returns(()=>It.IsAny<string>());

            //act
            var transformedStr = new FileTransformService().TransformXMLToHTML(xmlString, xsltString);

            //assert
			Assert.AreEqual(transformedStr, output);
        }
    }
}
