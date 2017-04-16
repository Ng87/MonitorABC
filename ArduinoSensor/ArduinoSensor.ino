/*
*/

// variable to hold sensor value
int sensorValue;

void setup() {
  Serial.begin(9600);
  while (!Serial)
	  ; // wait for serial port to connect. Needed for native USB port only
}

void loop() {
  //read the input from A0 and store it in a variable
  sensorValue = analogRead(A0);

  Serial.print("BrightnessSensor: ");
  Serial.println(sensorValue);

  // wait for 1 second
  delay(1000);
}

