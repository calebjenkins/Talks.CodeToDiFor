# Talks.CodeToDiFor
Demo code for "Code to DI for" - http://developingux.com/2016/03/14/code-to-di-for-in-ft-worth/

Objectives: 
- common dependency injection patterns
    - Constructor Injection
    - Property / Method Injection
    - LifeCycles (Singleton/Transient/Per Request)
- various IoC/DI frameworks
- practical steps and guidance
    - Using Conventions / Autoregistration
    - Avoiding "Common Service Locator" Pattern
    - Compositional Root
- real world scenarios
    - DI with Static Singletons
    - DI with Existing Types
    - DI with Collections (IList<T>)
    - Specifying Injected Dependencies
    - Forwarder pattern (for caching/retry logic on edges)
- impact to Unit Testing
    - DI with Mocks / Fakes
- application architecture
    - Compositional Root (Favor composition over inheritance)
    - Essentailly: realized SOLID