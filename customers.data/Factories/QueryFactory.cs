﻿using customers.data;

public static class QueryFactory
{
    private static ApplicationDbContext _context;

    private static PhoneCodeQuery _phoneCodeQuery;
    private static CustomerQuery _customerQuery; // Ejemplo de otra clase query
    // Agrega aquí más clases de tipo Query según sea necesario

    /// <summary>
    /// Inicializa el factory con el contexto de base de datos.
    /// Este método debe llamarse al inicio de la aplicación.
    /// </summary>
    public static void Initialize(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo.");
    }

    /// <summary>
    /// Obtiene una instancia de PhoneCodeQuery.
    /// </summary>
    public static PhoneCodeQuery GetPhoneCodeQuery()
    {
        if (_context == null)
        {
            throw new InvalidOperationException("El factory no ha sido inicializado con un contexto.");
        }

        return _phoneCodeQuery ??= new PhoneCodeQuery(_context); // Singleton para PhoneCodeQuery
    }

    /// <summary>
    /// Obtiene una instancia de CustomerQuery.
    /// </summary>
    public static CustomerQuery GetCustomerQuery()
    {
        if (_context == null)
        {
            throw new InvalidOperationException("El factory no ha sido inicializado con un contexto.");
        }

        return _customerQuery ??= new CustomerQuery(_context); // Singleton para CustomerQuery
    }

    // Agrega más métodos para otras clases de tipo Query
}