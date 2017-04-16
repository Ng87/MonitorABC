/*
*/

// variable to hold sensor value
int sensorValue;
String spin;

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(100);
  while (!Serial)
	  ; // wait for serial port to connect. Needed for native USB port only
}

void loop() {

	if (Serial.available()) {
		//read the input from A0 and store it in a variable
		spin = Serial.readStringUntil('\n');

		if (spin == "SensorQuery") {

			sensorValue = analogRead(A0);

			Serial.print("BrightnessSensor: ");
			Serial.println(sensorValue);
		}
	}
}

