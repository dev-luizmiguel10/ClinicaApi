# 🏥 ClinicaApi

API REST para gerenciamento de clínica médica desenvolvida com ASP.NET Core.

## 🚀 Tecnologias

- C#/ .NET
- ASP.NET Core
- Entity Framework Core
- SQL Server
- FluentValidation
- xUnit + Moq + Bogus (testes unitários)
- WebApplicationFactory + EF InMemory (testes de integração)

## 🧠 Arquitetura

Projeto desenvolvido utilizando:

- Application
- Domain
- Infraestrutura
- Exception
- Repository Pattern
- Unit Of Work

## 📌 Funcionalidades

- Cadastro de pacientes
- Cadastro de médicos
- Agendamento de consultas
- Validação de horários
- Integração com ViaCEP API

## 🧪 Testes
Projeto conta com testes unitários cobrindo:
- Agendamento com sucesso
- Validação de médico inexistente
- Validação de paciente inexistente
- Validação de data inválida

- ## 🔗 Testes de Integração
- POST /api/Agendamento com sucesso
- Médico inexistente retorna 400
- Paciente inexistente retorna 400
- Horário duplicado retorna 400

## ✅ Regras de Negócio
- Não permitir horários duplicados
- Validar existência do médico antes do agendamento
- Validar existência do paciente antes do agendamento
