#Example of SOAP client
#lufer
#See https://www.geeksforgeeks.org/python/making-soap-api-calls-using-python/
#Check with https://www.w3schools.com/xml/tempconvert.asmx
#Check with C# SOAP Service CalSimples: http://localhost:64019/Services/CalcSimples.asmx?WSDL

import requests
import xml.etree.ElementTree as ET

# 1. Novo URL do serviço
url = "http://localhost:50768/CalcWSPLuse.asmx"

xValue = 2
yValue = 5

# 2. Atualizar o namespace (por defeito no C# é http://tempuri.org/)
namespace = "http://ola.pt/"

envelop = f"""<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Soma xmlns="{namespace}">
      <x>{xValue}</x>
      <y>{yValue}</y>
    </Soma>
  </soap:Body>
</soap:Envelope>"""

# 3. O cabeçalho SOAPAction é obrigatório para serviços .asmx
options = {
    "Content-Type": "text/xml; charset=utf-8",
    "SOAPAction": f"{namespace}Soma"
}

try:
    response = requests.post(url, data=envelop, headers=options)
    s = response.text
    
    print("--- RESPOSTA RAW ---")
    print(s)

    # XML Parsing 
    root = ET.fromstring(s)

    # 4. Procurar o resultado com o namespace correto
    r = "0"
    for child in root.iter(f"{{{namespace}}}SomaResult"):
        r = child.text

    print(f"\nResultado da Soma (R): {r}")

except Exception as e:
    print(f"Erro na requisição: {e}")