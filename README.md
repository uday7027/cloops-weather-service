Weather Microservice (CLOOPS)
This project implements a weather microservice using the cloops.microservices SDK.
The service integrates with the public wttr.in API to fetch weather information for a given city.
Features
- Built using the official cloops.microservices.template
- External weather API integration using wttr.in
- Clean separation of controller and service layers
- Graceful error handling
- NATS-based request–reply architecture
Prerequisites
- .NET SDK
- NATS Server
- NATS CLI
Running the Service
1. Start the NATS server:
nats-server
2. Run the service:
./run.sh
Testing
Health Check:
nats request health.WeatherService '{}'
Weather Request:
nats request weather.request '{"city":"San Francisco"}'
Note on NATS Subject
This service follows the conventions provided by the official cloops.microservices.template.
The template exposes predefined internal NATS subjects (such as health.<service-name>),
which are verified to work.
The Weather handler logic and wttr.in integration are implemented according to the template’s
controller and service conventions.