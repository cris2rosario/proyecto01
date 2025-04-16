import numpy as np
import math

# 11) Bubble Sort
def bubble_sort(arr):
    n = len(arr)
    for i in range(n):
        for j in range(n - 1 - i):
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
    return arr

# 12) Búsqueda Lineal
def busqueda_lineal(arr, objetivo):
    for i in range(len(arr)):
        if arr[i] == objetivo:
            return i
    return -1

# 13) Suma iterativa y recursiva
def suma_iterativa(n):
    suma = 0
    for i in range(1, n+1):
        suma += i
    return suma

def suma_recursiva(n):
    if n == 0:
        return 0
    else:
        return n + suma_recursiva(n - 1)

# Entradas (puedes cambiar a input si quieres hacerlo dinámico)
filas1, cols1 = 2, 2
filas2, cols2 = 2, 2

# Generar matrices sin ceros
A = np.random.randint(1, 10, (filas1, cols1))
B = np.random.randint(1, 10, (filas2, cols2))

print("Matriz A:")
print(A)
print("Matriz B:")
print(B)

# a) Suma
if A.shape == B.shape:
    resultado_a = 3 * A + 4 * B
    print("\nResultado a) 3A + 4B:")
    print(resultado_a)

# b) Multiplicación: log10(B) sin ceros
if A.shape[1] == B.shape[0]:
    B_sin_ceros = np.where(B == 0, 0.1, B)
    log_B = np.log10(B_sin_ceros)
    resultado_b = 2 * A @ log_B
    print("\nResultado b) 2A * log10(B):")
    print(resultado_b)

# c) Sustracción
if A.shape == B.shape:
    resultado_c = A - np.sqrt(B)
    print("\nResultado c) A - sqrt(B):")
    print(resultado_c)

# d) A^3 * sqrt(B)
if A.shape == B.shape:
    resultado_d = (A**3) * np.sqrt(B)
    print("\nResultado d) A^3 * sqrt(B):")
    print(resultado_d)

# e) Simetría
if A.shape[0] == A.shape[1] and B.shape[0] == B.shape[1]:
    sim_A = np.array_equal(A, A.T)
    sim_B = np.array_equal(B, B.T)
    print(f"\n¿Matriz A es simétrica?: {sim_A}")
    print(f"¿Matriz B es simétrica?: {sim_B}")

# Ordenamiento y búsqueda
vector = A.flatten().tolist() + B.flatten().tolist()
print("\nVector combinado sin ordenar:", vector)

ordenado = bubble_sort(vector.copy())
print("Vector ordenado (bubble sort):", ordenado)

buscar = vector[0]
pos = busqueda_lineal(ordenado, buscar)
print(f"Elemento {buscar} encontrado en la posición: {pos}")

# Funciones iterativa y recursiva
print("\nSuma iterativa de los primeros 10 números:", suma_iterativa(10))
print("Suma recursiva de los primeros 10 números:", suma_recursiva(10))
