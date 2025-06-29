import numpy as np # type: ignore
import matplotlib.pyplot as plt # type: ignore
from scipy.fft import fft, fftfreq, fftshift # type: ignore

# Parámetros generales
fs = 1000  # frecuencia de muestreo (Hz)
T = 1.0    # duración de la señal (s)
N = int(fs * T)  # número de muestras
t = np.linspace(-T/2, T/2, N, endpoint=False)  # vector de tiempo

# Crear señales elementales
def rectangular_pulse(t, width=0.2):
    return np.where(np.abs(t) < width/2, 1.0, 0.0)

def step_function(t):
    return np.where(t >= 0, 1.0, 0.0)

def sinusoidal_signal(t, freq=50):
    return np.sin(2 * np.pi * freq * t)

# FFT y visualización
def plot_fft(signal, t, title="FFT", fs=1000):
    N = len(signal)
    freq = fftshift(fftfreq(N, 1/fs))
    spectrum = fftshift(fft(signal))
    magnitude = np.abs(spectrum)
    phase = np.angle(spectrum)

    plt.figure(figsize=(12, 5))

    plt.subplot(1, 2, 1)
    plt.plot(freq, magnitude)
    plt.title(f'{title} - Magnitud')
    plt.xlabel('Frecuencia (Hz)')
    plt.ylabel('|X(f)|')

    plt.subplot(1, 2, 2)
    plt.plot(freq, phase)
    plt.title(f'{title} - Fase')
    plt.xlabel('Frecuencia (Hz)')
    plt.ylabel('<X(f) [rad]')

    plt.tight_layout()
   
   

# Señales
pulse = rectangular_pulse(t)
step = step_function(t)
sine = sinusoidal_signal(t)

# Gráficos en dominio del tiempo
plt.figure(figsize=(10, 6))
plt.subplot(3, 1, 1)
plt.plot(t, pulse)
plt.xlabel('Tiempo [s]')
plt.ylabel('Amplitud')
plt.title("Pulso Rectangular")

plt.subplot(3, 1, 2)
plt.plot(t, step)
plt.xlabel('Tiempo [s]')
plt.ylabel('Amplitud')
plt.title("Funcion Escalon")

plt.subplot(3, 1, 3)
plt.plot(t, sine)
plt.xlabel('Tiempo [s]')
plt.ylabel('Amplitud')
plt.title("Se\u00f1al Senoidal")




plt.tight_layout()


# FFTs
plot_fft(pulse, t, "Pulso Rectangular")
plot_fft(step, t, "Funcion Escalon")
plot_fft(sine, t, "Se\u00f1al Senoidal")

# Propiedad de linealidad
suma = pulse + sine
plot_fft(suma, t, "Suma de Pulso + Senoide (Linealidad)")

# Propiedad de desplazamiento en el tiempo
sine_shifted = sinusoidal_signal(t - 0.1)
plot_fft(sine_shifted, t, "Senoide Desplazada en el Tiempo")

# Propiedad de escalamiento en frecuencia
sine_scaled = sinusoidal_signal(t, freq=100)  # doble de frecuencia
plot_fft(sine_scaled, t, "Senoide Escalada en Frecuencia (100 Hz)")



plt.show()