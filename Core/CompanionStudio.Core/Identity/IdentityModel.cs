namespace CompanionStudio.Core.Identity;


public class IdentityModel
{

    // ==============================
    // BASIC IDENTITY DATA
    // ==============================


    // Identificador único de la identidad
    public string Id { get; set; } = string.Empty;



    // Nombre visible de la identidad
    public string Name { get; set; } = string.Empty;



    // Versión del núcleo de identidad
    public string Version { get; set; } = "1.0";



    // Descripción inicial
    public string Description { get; set; } = string.Empty;



    // Fecha de creación
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    // Estado activo
    public bool IsActive { get; set; } = true;



    // ==============================
    // INTEGRITY SYSTEM
    // ==============================


    // Hash criptográfico de integridad
    public string IntegrityHash { get; set; } = string.Empty;



    // Estado visual para UI
    public string IntegrityStatus
    {
        get
        {
            return string.IsNullOrWhiteSpace(IntegrityHash)
                ? "Not Verified"
                : "Verified";
        }
    }



    // ==============================
    // IDENTITY CORE PROTECTION
    // ==============================


    // Bloqueo del núcleo
    public bool IsLocked { get; set; } = false;



    // Estado visual del bloqueo
    public string CoreLocked
    {
        get
        {
            return IsLocked
                ? "LOCKED"
                : "UNLOCKED";
        }
    }



    // Huella única de identidad
    public string IdentityFingerprint { get; set; } = string.Empty;



    // Alias para componentes UI
    public string Fingerprint
    {
        get
        {
            return string.IsNullOrWhiteSpace(IdentityFingerprint)
                ? "NONE"
                : IdentityFingerprint;
        }
    }

}