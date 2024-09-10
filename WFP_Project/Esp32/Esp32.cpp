#include <SPI.h>
#include <WiFi.h>
#include <WiFiClient.h>
#include <SIKTEC_SPI.h>
#include <PubSubClient.h>
#include <Adafruit_GFX.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_I2CDevice.h>

#define WIFI_SSID ""
#define WIFI_PASSWORD ""

const char* mqtt_server = "broker.hivemq.com";
const char* mqtt_topic_water = "fdSZlsSff2jQHdsjQWZA21o397W31wSdmvfSahj92183dOksji";

WiFiClient espClient;
PubSubClient client(espClient);

const int waterSensorPin = 32;

void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(WIFI_SSID);

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    String clientId = "ESP32Client-";
    clientId += String(random(0xffff), HEX);
    
    if (client.connect(clientId.c_str())) {
      Serial.println("connected");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}

void publishWaterLevel() {
  int waterRaw = analogRead(waterSensorPin); 
  float waterLevel = (waterRaw / 20475.0) * 100.0;

  Serial.print("Publishing water level: ");
  Serial.println(waterLevel);
  
  if (client.connected()) {
    client.publish(mqtt_topic_water, String(waterLevel).c_str());
  }
}

void setup() {
  Serial.begin(115200);
  
  setup_wifi();
  client.setServer(mqtt_server, 1883);
}

void loop() {
  if (!client.connected()) {
    reconnect();
  }
  
  client.loop();
  publishWaterLevel();
  
  delay(5000);
}
