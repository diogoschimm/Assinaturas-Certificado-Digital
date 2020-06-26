# Assinaturas-Certificado-Digital
Assinaturas e Criptografia com Certificados Digitais


## Obtendo o certificado a partir do PFX

Precisamos passar o caminho do arquivo PFX e a senha do arquivo, nesse caso estamos obtendo a partir de TextBox na Tela do Windows Forms, mas isso poderia estar em qualquer lugar.

```csharp
private X509Certificate2 GetX509Certificate2()
{
    return new X509Certificate2(txtCaminhoCertificado.Text, txtPassword.Text);
}
```

## XML

```csharp
private string GetStrXml()
{
    return $@"<root><creditcard><number>19834209</number><expiry>02/02/2002</expiry></creditcard></root>";
}
```

## Assinando o XML com a chave Privada

Vamos obter a chave privada do X509Certificate2 com o método GetRSAPrivateKey() e assinar o XML

```csharp
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
```

Para assinar o XML vamos utilizar o seguinte código, o método ComputeSignature() cria a assinatura e o método GetXml() obtém o trecho de xml correpondente a assinatura, agora temos que colocar esse nó de assinatura dentro do xml original.

```csharp
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
```

## Verificando a Assinatura do XML com a Chave Pública

Para verificar o documento vamos utilizar o arquivo anteriormente criado (cujo nome é Assinado.xml) vamos obter a chave pública do certificado através do método GetRSAPublicKey() e vamos chamar o método VerifyXml.


```csharp
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
```

O método VerifyXml recebe o objeto XmlDocument que representa o arquivo XML e a Chave RSA (nesse caso a chave publica) porque ciframos utilizando a Chave Privada.  Vamos utilizar o método CheckSignature passando a Chave como parâmetro, esse método retorna um boleano.

```csharp
public static bool VerifyXml(XmlDocument xmlDoc, RSA key)
{
    SignedXml signedXml = new SignedXml(xmlDoc);
    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");

    signedXml.LoadXml((XmlElement)nodeList[0]);

    return signedXml.CheckSignature(key);
}
```

# Criptografia

## Cifragem dos dados

Para cifrar os dados vamos obter o certificado X509 e vamos chamar o método Encrypt

```csharp
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
```

Vamos chamar o método Encrypt do EncryptedXml Object.

```csharp
public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, X509Certificate2 Cert)
{
    var elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;
    var edElement = new EncryptedXml().Encrypt(elementToEncrypt, Cert);

    EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
}
```

## Decifragem dos dados

A decifragem não utiliza o arquivo PFX, é necessário que o certificado esteja instalado no Repositório de Certificados Pessoal do Usuário Atual.

```csharp
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
```

Para decriptar os dados vamos chamar o método DecriptDocument(), a chave deverá estar instalada no certificado digital no repositório do windows.

```csharp
public static void Decrypt(XmlDocument doc)
{
    var exml = new EncryptedXml(doc);
    exml.DecryptDocument();
}
```

Para obter certificados de teste para assinar, verificar assinaturas, crifrar e decifrar dados utilize os comandos do repositório, lá eu mostro como criar certificados digitais para teste em aplicações Asp.net

https://github.com/diogoschimm/PowerShell-Autoridade-Certificadora-Certificados


