using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Xml;

namespace CertificadoDigital
{
    public partial class FrmAssinador : Form
    {
        public FrmAssinador()
        {
            InitializeComponent();
        }

        private void btnAssinarXml_Click(object sender, EventArgs e)
        {
            TryExec(() =>
            {
                var rsaPrivateKey = GetX509Certificate2().GetRSAPrivateKey();

                var xmlDoc = CreateXmlDocument();
                xmlDoc.LoadXml(GetStrXml());

                SignXml(xmlDoc, rsaPrivateKey);

                xmlDoc.Save("Assinado.xml");

                MessageBox.Show("Assinatura realizada com sucesso");
            });
        }

        private void btnVerificarAssinatura_Click(object sender, EventArgs e)
        {
            TryExec(() =>
            {
                var rsaPublicKey = GetX509Certificate2().GetRSAPublicKey();

                var xmlDoc = CreateXmlDocument();
                xmlDoc.Load("Assinado.xml");

                if (VerifyXml(xmlDoc, rsaPublicKey))
                    MessageBox.Show("Assinatura verificada com sucesso");
                else
                    MessageBox.Show("Assinatura não corresponde ao Certificado Informado");
            });
        }

        private void btnCriptografar_Click(object sender, EventArgs e)
        {
            TryExec(() =>
            {
                var cert = GetX509Certificate2();

                var xmlDoc = CreateXmlDocument();
                xmlDoc.LoadXml(GetStrXml());

                Encrypt(xmlDoc, "root", cert);

                xmlDoc.Save("Encriptado.xml");

                MessageBox.Show("Cifragem realizada com sucesso");
            });
        }

        private void btnDescriptografar_Click(object sender, EventArgs e)
        {
            TryExec(() =>
            {
                var xmlDoc = CreateXmlDocument();
                xmlDoc.Load("Encriptado.xml");

                Decrypt(xmlDoc);

                xmlDoc.Save("Decriptado.xml");

                MessageBox.Show("Decifragem realizada com sucesso");
            });
        }

        private string GetStrXml()
        {
            return $@"<root><creditcard><number>19834209</number><expiry>02/02/2002</expiry></creditcard></root>";
        }
        private X509Certificate2 GetX509Certificate2()
        {
            return new X509Certificate2(txtCaminhoCertificado.Text, txtPassword.Text);
        }
        private XmlDocument CreateXmlDocument()
        {
            var xmlDoc = new XmlDocument
            {
                PreserveWhitespace = true
            };
            return xmlDoc;
        }

        public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, X509Certificate2 Cert)
        {
            var elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;
            var edElement = new EncryptedXml().Encrypt(elementToEncrypt, Cert);

            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
        }

        public static void Decrypt(XmlDocument doc)
        {
            var exml = new EncryptedXml(doc);
            exml.DecryptDocument();
        }

        public static void SignXml(XmlDocument xmlDoc, RSA rsaKey)
        {
            var signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = rsaKey;

            var reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

            signedXml.AddReference(reference);
            signedXml.ComputeSignature();

            var xmlDigitalSignature = signedXml.GetXml();
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }
        public static bool VerifyXml(XmlDocument xmlDoc, RSA key)
        {
            SignedXml signedXml = new SignedXml(xmlDoc);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");

            signedXml.LoadXml((XmlElement)nodeList[0]);

            return signedXml.CheckSignature(key);
        }

        private void TryExec(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
