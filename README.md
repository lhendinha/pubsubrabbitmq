# PubSubRabbitmq

## Overview
PubSubRabbitmq is a personal project built using .NET Core 7 and RabbitMQ database, designed for implementing a publish-subscribe pattern. This project utilizes Docker to facilitate easy deployment and management.

## Purpose
The primary objective of this project is to demonstrate the implementation of a publish-subscribe messaging pattern using RabbitMQ in the context of a .NET Core application. The project specifically focuses on creating a simple event-driven system where a customer creation event triggers various subscribers to log the event to the console.

## Features
- Utilizes .NET Core 7 for the application logic.
- Integrates RabbitMQ as the messaging broker.
- Docker support for simplified deployment and containerization.

## Getting Started
To run the project, follow these steps:

1. Ensure you have Docker installed on your system.
2. Clone this repository to your local machine.
3. Navigate to the project directory.
4. Run the following command to start the Docker containers:
   ```
   docker-compose up -d
   ```
5. Once the containers are up and running, the system should be ready to publish and subscribe to events.

## Usage
1. The application simulates the creation of a customer entity.
2. Subscribers are configured to listen for customer creation events.
3. Upon receiving the event, each subscriber logs the event details to the console.

## Contributing
Contributions to this project are welcome. If you'd like to contribute, please fork the repository, make your changes, and submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE).

## Disclaimer
This project is intended for educational and demonstration purposes only. It may not be suitable for production environments without further development and testing. Use it at your own risk.

## Contact
For any inquiries or support regarding this project, feel free to contact the project maintainer [insert your email or contact information here].

Happy coding! 🚀