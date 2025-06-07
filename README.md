# TravelSaga

[![Build & Test Status](https://github.com/abbasghomi/TravelSaga/actions/workflows/dotnet.yml/badge.svg?label=Build%20%26%20Test)](https://github.com/abbasghomi/TravelSaga/actions/workflows/dotnet.yml)

> Automated build and test status provided by GitHub Actions.

Welcome to TravelSaga! This repository demonstrates a robust implementation of the Saga pattern in .NET 9, designed to coordinate complex, long-running business processes across distributed services. If you're looking to understand, implement, or extend the Saga orchestration pattern, you're in the right place.

## What is the Saga Pattern?
The Saga pattern is a microservices architectural pattern for managing distributed transactions. Instead of a single, atomic transaction, a saga coordinates a series of local transactions, each with its own compensating action in case of failure. This approach ensures data consistency and reliability in distributed systems where traditional transactions are impractical.

## Project Structure

- **TravelSaga**: The core library containing saga orchestrators, step contracts, and concrete implementations for various travel booking operations (flights, hotels, insurance, etc.).
- **TravelSagaTest**: A comprehensive test suite covering orchestrator logic, individual saga steps, and utility components to ensure reliability and correctness.

## Key Features
- Modular saga orchestrator and step contracts for extensibility.
- Concrete implementations for common travel-related operations:
  - BookFlightStep
  - ReserveHotelStep
  - BookTravelInsuranceStep
  - ArrangeVisaStep
  - BookAirportTransferStep
  - RentCarStep
  - ReserveRestaurantStep
  - ReserveTourStep
  - BookEventTicketsStep
  - PurchaseSIMCardStep
- Failure simulation utilities for robust testing.
- Clean separation of concerns and testable architecture.

## Getting Started

1. **Clone the repository:** git clone https://github.com/abbasghomi/TravelSaga.git
2. **Build the solution:** dotnet build
3. **Run tests:** dotnet test
4. **Explore the code:**
   - Start with `TravelSaga/Sagas/TravelBookingSaga.cs` for the main orchestrator logic.
   - Review step implementations in `TravelSaga/Steps/`.
   - Check out tests in `TravelSagaTest/` for usage examples.

## Extending the Solution
- **Add a new saga step:**
  1. Implement the `ISagaStep` interface in a new class under `TravelSaga/Steps/`.
  2. Register your step in the orchestrator (`TravelBookingSaga.cs`).
  3. Add corresponding tests in `TravelSagaTest/StepTests/`.
- **Create a new orchestrator:**
  1. Implement the `ISagaOrchestrator` interface.
  2. Compose your saga steps as needed.

## Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements, bug fixes, or new features. For major changes, start a discussion to ensure alignment with project goals.

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

---

If you have questions or suggestions, feel free to open an issue. Happy coding!
