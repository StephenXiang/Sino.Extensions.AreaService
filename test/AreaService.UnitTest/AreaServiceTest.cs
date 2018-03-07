using Sino.Extensions.AreaService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SinoAreaService.UnitTest
{
    public class AreaServiceTest
    {
        private IAreaService _area;

        public AreaServiceTest()
        {
            Stopwatch watch = Stopwatch.StartNew();
            _area = new AreaService();
            watch.Stop();
        }

        [Fact]
        public void TestGetProvinceCodeByName()
        {
            var code = _area.GetCode("����");
            Assert.Equal(code, "01");

            code = _area.GetCode("ɽ��");
            Assert.Equal(code, "04");

            code = _area.GetCode("����");
            Assert.Equal(code, "07");

            code = _area.GetCode("�Ϻ�");
            Assert.Equal(code, "09");

            code = _area.GetCode("����");
            Assert.Equal(code, "18");

            code = _area.GetCode("����");
            Assert.Equal(code, "21");

            code = _area.GetCode("����");
            Assert.Equal(code, "27");

            code = _area.GetCode("�½�");
            Assert.Equal(code, "31");

            code = _area.GetCode("���");
            Assert.Equal(code, "33");

            code = _area.GetCode("����");
            Assert.Equal(code, "34");
        }

        [Fact]
        public void TestGetCityCodeByName()
        {
            var code = _area.GetCode("����", "�뵺");
            Assert.Equal(code, "3402");

            code = _area.GetCode("���", "�½�");
            Assert.Equal(code, "3303");

            code = _area.GetCode("����", "��ԭ");
            Assert.Equal(code, "3004");

            code = _area.GetCode("����", "��ˮ");
            Assert.Equal(code, "2805");

            code = _area.GetCode("����", "������");
            Assert.Equal(code, "2802");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "2502");

            code = _area.GetCode("����", "��ɽ");
            Assert.Equal(code, "2504");

            code = _area.GetCode("�Ĵ�", "�Թ�");
            Assert.Equal(code, "2302");

            code = _area.GetCode("�Ĵ�", "����");
            Assert.Equal(code, "2304");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "2003");

            code = _area.GetCode("�㶫", "�ع�");
            Assert.Equal(code, "1902");

            code = _area.GetCode("�㶫", "��ͷ");
            Assert.Equal(code, "1905");

            code = _area.GetCode("����", "֣��");
            Assert.Equal(code, "1601");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "1605");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "1302");

            code = _area.GetCode("����", "Ȫ��");
            Assert.Equal(code, "1305");

            code = _area.GetCode("�㽭", "����");
            Assert.Equal(code, "1101");

            code = _area.GetCode("�㽭", "����");
            Assert.Equal(code, "1103");

            code = _area.GetCode("����", "�Ͼ�");
            Assert.Equal(code, "1001");

            code = _area.GetCode("����", "��");
            Assert.Equal(code, "1011");

            code = _area.GetCode("������", "������");
            Assert.Equal(code, "0801");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "0702");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "0601");

            code = _area.GetCode("���ɹ�", "��ͷ");
            Assert.Equal(code, "0502");

            code = _area.GetCode("�ӱ�", "ʯ��ׯ");
            Assert.Equal(code, "0301");

            code = _area.GetCode("�ӱ�", "��ɽ");
            Assert.Equal(code, "0302");

            code = _area.GetCode("�ӱ�", "����");
            Assert.Equal(code, "0304");

            code = _area.GetCode("����", "����");
            Assert.Equal(code, "0101");
        }

        [Fact]
        public void TestGetCountyCodeByCode()
        {
            var code = _area.GetCode("����", "����", "��̨��");
            Assert.Equal(code, "010106");

            code = _area.GetCode("����", "����Ͻ��", "������");
            Assert.Equal(code, "010201");

            code = _area.GetCode("�ӱ�", "ʯ��ׯ", "����");
            Assert.Equal(code, "030101");

            code = _area.GetCode("�ӱ�", "��ɽ", "����");
            Assert.Equal(code, "030208");

            code = _area.GetCode("ɽ��", "̫ԭ", "����");
            Assert.Equal(code, "040101");

            code = _area.GetCode("ɽ��", "̫ԭ", "��Դ��");
            Assert.Equal(code, "040107");

            code = _area.GetCode("ɽ��", "̫ԭ", "�Ž���");
            Assert.Equal(code, "040111");
        }

        [Fact]
        public void TestGetAreaNameByCode()
        {
            var name = _area.GetAreaName("040111");
            Assert.Equal(name, "ɽ��̫ԭ�Ž���");

            name = _area.GetAreaName("040107");
            Assert.Equal(name, "ɽ��̫ԭ��Դ��");

            name = _area.GetAreaName("040101");
            Assert.Equal(name, "ɽ��̫ԭ����");

            name = _area.GetAreaName("030208");
            Assert.Equal(name, "�ӱ���ɽ����");

            name = _area.GetAreaName("030101");
            Assert.Equal(name, "�ӱ�ʯ��ׯ����");

            name = _area.GetAreaName("0101");
            Assert.Equal(name, "��������");

            name = _area.GetAreaName("1011");
            Assert.Equal(name, "������");

            name = _area.GetAreaName("10");
            Assert.Equal(name, "����");

            name = _area.GetAreaName("030101", false);
            Assert.Equal(name, "����");

            name = _area.GetAreaName("1011", false);
            Assert.Equal(name, "��");
        }

        [Fact]
        public void TestGetCityCodeByProvinceCode()
        {

        }

        [Fact]
        public void TestProvinceEqualCode()
        {
            for (int i = 0; i < _area.ProvinceCodes.Count; i++)
            {
                var code = _area.ProvinceCodes[i];
                var name = _area.ProvinceNames[i];

                var destCode = _area.GetCode(name);

                Assert.Equal(code, destCode);
            }
        }
    }
}