using PricatMVC.Dtos;
using PricatMVC.Interfaces;
using PricatMVC.Models;

namespace PricatMVC.Services;

public class ProductService : IService<Product>
{
    #region Global-Variables

    private static List<Product> productList = InitializeData();

    #endregion Global-Variables

    #region Constructor

    public ProductService()
    {
    }

    #endregion Constructor

    #region Public-Methods

    public Product Create(Product product)
    {
        return CreateProduct(product);
    }

    public void Delete(int id)
    {
        RemoveProduct(id);
    }

    public Product Edit(Product product)
    {
        return EditProduct(product);
    }

    public List<Product> GetAll()
    {
        return GetAllProducts();
    }

    public Product GetById(int id)
    {
        return GetProductById(id);
    }

    public QueryResult<Product> GetByPage(int page, int limit)
    {
        var productList = GetProductsByPage(page, limit);

        var queryResult = new QueryResult<Product>()
        {
            Items = productList,
            Pagination = new PaginationData()
            {
                Page = page,
                Limit = limit
            }
        };

        return queryResult;
    }

    #endregion Public-Methods

    #region Private-Methods

    private static List<Product> InitializeData()
    {
        var products = new List<Product>()
        {
            new Product() {Id= 1, CategoryId= 1, EanCode= "7707248000429", Description= "Leche",  Price= 3750,  Unit= "Litro"},
            new Product() {Id= 2, CategoryId= 1, EanCode= "7707248005868", Description= "Pan",  Price= 5500,  Unit= "Unidad"},
            new Product() {Id= 3, CategoryId= 1, EanCode= "7707248015607", Description= "Arroz",  Price= 4500,  Unit= "Kilogramo"},
            new Product() {Id= 4, CategoryId= 1, EanCode= "7707248023831", Description= "Frijoles",  Price= 3000,  Unit= "Kilogramo"},
            new Product() {Id= 5, CategoryId= 1, EanCode= "7707248027082", Description= "Huevos",  Price= 18000,  Unit= "Unidad"},
            new Product() {Id= 6, CategoryId= 1, EanCode= "7707248028539", Description= "Carne de res",  Price= 15000,  Unit= "Kilogramo"},
            new Product() {Id= 7, CategoryId= 1, EanCode= "7707248031553", Description= "Pollo",  Price= 12000,  Unit= "Kilogramo"},
            new Product() {Id= 8, CategoryId= 1, EanCode= "7707248032444", Description= "Atún enlatado",  Price= 11000,  Unit= "Lata"},
            new Product() {Id= 9, CategoryId= 1, EanCode= "7707248034080", Description= "Queso",  Price= 7500,  Unit= "Kilogramo"},
            new Product() {Id= 10, CategoryId= 1, EanCode= "7707248034707", Description= "Yogur",  Price= 6500,  Unit= "Unidad"},
            new Product() {Id= 11, CategoryId= 1, EanCode= "7707248036640", Description= "Cebolla",  Price= 950,  Unit= "Kilogramo"},
            new Product() {Id= 12, CategoryId= 1, EanCode= "7707248039832", Description= "Tomate",  Price= 1200,  Unit= "Kilogramo"},
            new Product() {Id= 13, CategoryId= 2, EanCode= "7707248044249", Description= "Agua mineral",  Price= 2500,  Unit= "Botella (500 ml)"},
            new Product() {Id= 14, CategoryId= 2, EanCode= "7707248045529", Description= "Refresco de cola",  Price= 3700,  Unit= "Botella (600 ml)"},
            new Product() {Id= 15, CategoryId= 2, EanCode= "7707248052329", Description= "Jugo de naranja",  Price= 3500,  Unit= "Botella (1 litro)"},
            new Product() {Id= 16, CategoryId= 2, EanCode= "7707248066999", Description= "Té helado",  Price= 2000,  Unit= "Botella (500 ml)"},
            new Product() {Id= 17, CategoryId= 2, EanCode= "7707248068504", Description= "Limonada",  Price= 1500,  Unit= "Vaso (350 ml)"},
            new Product() {Id= 18, CategoryId= 2, EanCode= "7707248074710", Description= "Café",  Price= 1000,  Unit= "Taza (250 ml)"},
            new Product() {Id= 19, CategoryId= 2, EanCode= "7707248087246", Description= "Cerveza",  Price= 6500,  Unit= "Botella (355 ml)"},
            new Product() {Id= 20, CategoryId= 2, EanCode= "7707248092295", Description= "Vino tinto",  Price= 25000,  Unit= "Botella (750 ml)"},
            new Product() {Id= 21, CategoryId= 2, EanCode= "7707248095814", Description= "Licor de ron",  Price= 35000,  Unit= "Botella (750 ml)"},
            new Product() {Id= 22, CategoryId= 2, EanCode= "7707248102482", Description= "Whisky",  Price= 65000,  Unit= "Botella (750 ml)"},
            new Product() {Id= 23, CategoryId= 2, EanCode= "7707248103717", Description= "Refresco de naranja",  Price= 1800,  Unit= "Botella (600 ml)"},
            new Product() {Id= 24, CategoryId= 2, EanCode= "7707248105186", Description= "Agua con gas",  Price= 3200,  Unit= "Botella (500 ml)"},
            new Product() {Id= 25, CategoryId= 3, EanCode= "7707248113426", Description= "Papel higiénico",  Price= 6250,  Unit= "Rollo (4 unidades)"},
            new Product() {Id= 26, CategoryId= 3, EanCode= "7707248113846", Description= "Jabón de tocador",  Price= 12500,  Unit= "Barra (100 g)"},
            new Product() {Id= 27, CategoryId= 3, EanCode= "7707248118216", Description= "Desodorante",  Price= 8900,  Unit= "Unidad"},
            new Product() {Id= 28, CategoryId= 3, EanCode= "7707248132236", Description= "Champú",  Price= 13200,  Unit= "Botella (500 ml)"},
            new Product() {Id= 29, CategoryId= 3, EanCode= "7707248135794", Description= "Acondicionador",  Price= 12100,  Unit= "Botella (500 ml)"},
            new Product() {Id= 30, CategoryId= 3, EanCode= "7707248143522", Description= "Crema dental",  Price= 14000,  Unit= "Tubo (120 g)"},
            new Product() {Id= 31, CategoryId= 3, EanCode= "7707248144635", Description= "Enjuague bucal",  Price= 23000,  Unit= "Botella (500 ml)"},
            new Product() {Id= 32, CategoryId= 3, EanCode= "7707248159844", Description= "Toallas femeninas",  Price= 9500,  Unit= "Paquete (10 unidades)"},
            new Product() {Id= 33, CategoryId= 3, EanCode= "7707248160048", Description= "Papel absorbente",  Price= 12500,  Unit= "Rollo (50 hojas)"},
            new Product() {Id= 34, CategoryId= 3, EanCode= "7707248162400", Description= "Detergente para ropa",  Price= 16250,  Unit= "Botella (1 litro)"},
            new Product() {Id= 35, CategoryId= 3, EanCode= "7707248166903", Description= "Suavizante de telas",  Price= 1530,  Unit= "Botella (500 ml)"},
            new Product() {Id= 36, CategoryId= 3, EanCode= "7707248169331", Description= "Limpiador multiusos",  Price= 8600,  Unit= "Botella (500 ml)"},
            new Product() {Id= 37, CategoryId= 4, EanCode= "7707248170443", Description= "Camisa de algodón",  Price= 25000,  Unit= "Unidad"},
            new Product() {Id= 38, CategoryId= 4, EanCode= "7707248173628", Description= "Pantalón de mezclilla",  Price= 30000,  Unit= "Unidad"},
            new Product() {Id= 39, CategoryId= 4, EanCode= "7707248179002", Description= "Camiseta",  Price= 15000,  Unit= "Unidad"},
            new Product() {Id= 40, CategoryId= 4, EanCode= "7707248186444", Description= "Vestido",  Price= 40000,  Unit= "Unidad"},
            new Product() {Id= 41, CategoryId= 4, EanCode= "7707248187762", Description= "Blusa",  Price= 20000,  Unit= "Unidad"},
            new Product() {Id= 42, CategoryId= 4, EanCode= "7707248194784", Description= "Falda",  Price= 25000,  Unit= "Unidad"},
            new Product() {Id= 43, CategoryId= 4, EanCode= "7707248196207", Description= "Traje de baño",  Price= 35000,  Unit= "Unidad"},
            new Product() {Id= 44, CategoryId= 4, EanCode= "7707248197983", Description= "Calcetines",  Price= 5000,  Unit= "Par"},
            new Product() {Id= 45, CategoryId= 4, EanCode= "7707248198935", Description= "Zapatos deportivos",  Price= 50000,  Unit= "Par"},
            new Product() {Id= 46, CategoryId= 4, EanCode= "7707248201567", Description= "Chaqueta de cuero",  Price= 100000,  Unit= "Unidad"},
            new Product() {Id= 47, CategoryId= 4, EanCode= "7707248202274", Description= "Gorra",  Price= 10000,  Unit= "Unidad"},
            new Product() {Id= 48, CategoryId= 4, EanCode= "7707248202854", Description= "Pantuflas",  Price= 15000,  Unit= "Par"},
            new Product() {Id= 49, CategoryId= 5, EanCode= "7707248205671", Description= "Paracetamol",  Price= 1300,  Unit= "Caja (10 tabs de 500 mg)"},
            new Product() {Id= 50, CategoryId= 5, EanCode= "7707248206906", Description= "Ibuprofeno",  Price= 14000,  Unit= "Caja (20 tabs de 400 mg)"},
            new Product() {Id= 51, CategoryId= 5, EanCode= "7707248211078", Description= "Aspirina",  Price= 12500,  Unit= "Caja (30 tabs de 500 mg)"},
            new Product() {Id= 52, CategoryId= 5, EanCode= "7707248211306", Description= "Loratadina",  Price= 15000,  Unit= "Caja (10 tabs de 10 mg)"},
            new Product() {Id= 53, CategoryId= 5, EanCode= "7707248215472", Description= "Dipirona",  Price= 2000,  Unit= "Caja (20 tabs de 500 mg)"},
            new Product() {Id= 54, CategoryId= 5, EanCode= "7707248232608", Description= "Omeprazol",  Price= 6000,  Unit= "Caja (14 cáps de 20 mg)"},
            new Product() {Id= 55, CategoryId= 5, EanCode= "7707248237528", Description= "Amoxicilina",  Price= 8000,  Unit= "Caja (20 cáps de 500 mg)"},
            new Product() {Id= 56, CategoryId= 5, EanCode= "7707248240269", Description= "Paroxetina",  Price= 10000,  Unit= "Caja (30 tabs de 20 mg)"},
            new Product() {Id= 57, CategoryId= 5, EanCode= "7707248249927", Description= "Metformina",  Price= 4500,  Unit= "Caja (30 tabs de 850 mg)"},
            new Product() {Id= 58, CategoryId= 5, EanCode= "7707248250978", Description= "Atorvastatina",  Price= 12000,  Unit= "Caja (30 tabs de 10 mg)"},
            new Product() {Id= 59, CategoryId= 5, EanCode= "7707248251173", Description= "Vitamina C",  Price= 3500,  Unit= "Caja (30 tabs de 500 mg)"},
            new Product() {Id= 60, CategoryId= 5, EanCode= "7707248252903", Description= "Clorfenamina",  Price= 3000,  Unit= "Caja (10 tabs de 4 mg)"},
            new Product() {Id= 61, CategoryId= 6, EanCode= "7707248259735", Description= "Martillo",  Price= 32000,  Unit= "Unidad"},
            new Product() {Id= 62, CategoryId= 6, EanCode= "7707248269062", Description= "Destornillador",  Price= 13500,  Unit= "Unidad"},
            new Product() {Id= 63, CategoryId= 6, EanCode= "7707248272253", Description= "Taladro",  Price= 50000,  Unit= "Unidad"},
            new Product() {Id= 64, CategoryId= 6, EanCode= "7707248284980", Description= "Sierra circular",  Price= 70000,  Unit= "Unidad"},
            new Product() {Id= 65, CategoryId= 6, EanCode= "7707248290462", Description= "Llave inglesa",  Price= 8000,  Unit= "Unidad"},
            new Product() {Id= 66, CategoryId= 6, EanCode= "7707248291223", Description= "Pinzas",  Price= 4000,  Unit= "Unidad"},
            new Product() {Id= 67, CategoryId= 6, EanCode= "7707248292831", Description= "Cinta métrica",  Price= 13500,  Unit= "Unidad"},
            new Product() {Id= 68, CategoryId= 6, EanCode= "7707248298369", Description= "Nivel de burbuja",  Price= 7000,  Unit= "Unidad"},
            new Product() {Id= 69, CategoryId= 6, EanCode= "7707248308082", Description= "Serrucho",  Price= 12000,  Unit= "Unidad"},
            new Product() {Id= 70, CategoryId= 6, EanCode= "7707248319651", Description= "Llave de tubo",  Price= 10000,  Unit= "Unidad"},
            new Product() {Id= 71, CategoryId= 6, EanCode= "7707248328653", Description= "Pistola de calor",  Price= 25000,  Unit= "Unidad"},
            new Product() {Id= 72, CategoryId= 6, EanCode= "7707248333589", Description= "Lijadora de banda",  Price= 60000,  Unit= "Unidad"},
            new Product() {Id= 73, CategoryId= 7, EanCode= "7707248333848", Description= "Manzanas",  Price= 2500,  Unit= "Kilogramo"},
            new Product() {Id= 74, CategoryId= 7, EanCode= "7707248336825", Description= "Plátanos",  Price= 1250,  Unit= "Kilogramo"},
            new Product() {Id= 75, CategoryId= 7, EanCode= "7707248350807", Description= "Naranjas",  Price= 2000,  Unit= "Kilogramo"},
            new Product() {Id= 76, CategoryId= 7, EanCode= "7707248357646", Description= "Fresas",  Price= 4000,  Unit= "Kilogramo"},
            new Product() {Id= 77, CategoryId= 7, EanCode= "7707248362169", Description= "Piñas",  Price= 2500,  Unit= "Unidad"},
            new Product() {Id= 78, CategoryId= 7, EanCode= "7707248363609", Description= "Sandías",  Price= 5000,  Unit= "Unidad"},
            new Product() {Id= 79, CategoryId= 7, EanCode= "7707248367690", Description= "Melones",  Price= 3500,  Unit= "Unidad"},
            new Product() {Id= 80, CategoryId= 7, EanCode= "7707248376319", Description= "Mangos",  Price= 2500,  Unit= "Kilogramo"},
            new Product() {Id= 81, CategoryId= 7, EanCode= "7707248377767", Description= "Uvas",  Price= 300,  Unit= "Kilogramo"},
            new Product() {Id= 82, CategoryId= 7, EanCode= "7707248386516", Description= "Papayas",  Price= 2000,  Unit= "Kilogramo"},
            new Product() {Id= 83, CategoryId= 7, EanCode= "7707248387643", Description= "Kiwis",  Price= 6000,  Unit= "Kilogramo"},
            new Product() {Id= 84, CategoryId= 7, EanCode= "7707248389180", Description= "Limones",  Price= 1500,  Unit= "Kilogramo"},
            new Product() {Id= 85, CategoryId= 8, EanCode= "7707248392746", Description= "Anillo de oro blanco",  Price= 50000,  Unit= "Unidad"},
            new Product() {Id= 86, CategoryId= 8, EanCode= "7707248410266", Description= "Aretes de plata con zirconia",  Price= 25000,  Unit= "Par"},
            new Product() {Id= 87, CategoryId= 8, EanCode= "7707248417340", Description= "Pulsera de perlas",  Price= 200000,  Unit= "Unidad"},
            new Product() {Id= 88, CategoryId= 8, EanCode= "7707248418330", Description= "Collar de plata con dije de corazón",  Price= 80000,  Unit= "Unidad"},
            new Product() {Id= 89, CategoryId= 8, EanCode= "7707248420050", Description= "Anillo de compromiso con diamante",  Price= 200000,  Unit= "Unidad"},
            new Product() {Id= 90, CategoryId= 8, EanCode= "7707248420630", Description= "Aretes de oro amarillo con perlas",  Price= 150000,  Unit= "Par"},
            new Product() {Id= 91, CategoryId= 8, EanCode= "7707248442823", Description= "Pulsera de oro rosa con dije de inicial",  Price= 300000,  Unit= "Unidad"},
            new Product() {Id= 92, CategoryId= 8, EanCode= "7707248444063", Description= "Collar de oro blanco con diamantes",  Price= 1000000,  Unit= "Unidad"},
            new Product() {Id= 93, CategoryId= 8, EanCode= "7707248486650", Description= "Anillo de plata con piedra de ópalo",  Price= 60000,  Unit= "Unidad"},
            new Product() {Id= 94, CategoryId= 8, EanCode= "7707248488425", Description= "Aretes de oro blanco con diamantes",  Price= 400000,  Unit= "Par"},
            new Product() {Id= 95, CategoryId= 8, EanCode= "7707248494204", Description= "Pulsera de oro amarillo con dijes de corazón",  Price= 250000,  Unit= "Unidad"},
            new Product() {Id= 96, CategoryId= 8, EanCode= "7707248496123", Description= "Collar de plata con colgante de luna",  Price= 40000,  Unit= "Unidad"},
            new Product() {Id= 97, CategoryId= 9, EanCode= "7707248499001", Description= "Laptop Lenovo",  Price= 9000000,  Unit= "Unidad"},
            new Product() {Id= 98, CategoryId= 9, EanCode= "7707248501261", Description= "Teléfono iPhone 13",  Price= 11000000,  Unit= "Unidad"},
            new Product() {Id= 99, CategoryId= 9, EanCode= "7707248508628", Description= "Tableta Samsung Galaxy Tab S7",  Price= 600000,  Unit= "Unidad"},
            new Product() {Id= 100, CategoryId= 9, EanCode= "7707248518092", Description= "Televisor LG 55 pulgadas 4K",  Price= 700000,  Unit= "Unidad"},
            new Product() {Id= 101, CategoryId= 9, EanCode= "7707248523973", Description= "Auriculares inalámbricos Sony",  Price= 150000,  Unit= "Par"},
            new Product() {Id= 102, CategoryId= 9, EanCode= "7707248525854", Description= "Altavoz Bluetooth JBL",  Price= 80000,  Unit= "Unidad"},
            new Product() {Id= 103, CategoryId= 9, EanCode= "7707248528381", Description= "Consola de videojuegos PlayStation 5",  Price= 500000,  Unit= "Unidad"},
            new Product() {Id= 104, CategoryId= 9, EanCode= "7707248533309", Description= "Cámara Canon EOS R6",  Price= 2500000,  Unit= "Unidad"},
            new Product() {Id= 105, CategoryId= 9, EanCode= "7707248537314", Description= "Monitor Dell 27 pulgadas",  Price= 400000,  Unit= "Unidad"},
            new Product() {Id= 106, CategoryId= 9, EanCode= "7707248538366", Description= "Router WiFi TP-Link",  Price= 500000,  Unit= "Unidad"},
            new Product() {Id= 107, CategoryId= 9, EanCode= "7707248547405", Description= "Disco duro externo Seagate 2TB",  Price= 100000,  Unit= "Unidad"},
            new Product() {Id= 108, CategoryId= 9, EanCode= "7707248550245", Description= "Impresora HP OfficeJet Pro 9015",  Price= 3000000,  Unit= "Unidad"},
            new Product() {Id= 109, CategoryId= 10, EanCode= "7707248555172", Description= "Muñeca Barbie",  Price= 20000,  Unit= "Unidad"},
            new Product() {Id= 110, CategoryId= 10, EanCode= "7707248556032", Description= "Coche de carreras de control remoto",  Price= 50000,  Unit= "Unidad"},
            new Product() {Id= 111, CategoryId= 10, EanCode= "7707248559019", Description= "Set de bloques de construcción LEGO",  Price= 30000,  Unit= "Unidad"},
            new Product() {Id= 112, CategoryId= 10, EanCode= "7707248565324", Description= "Juego de mesa Monopoly",  Price= 25000,  Unit= "Unidad"},
            new Product() {Id= 113, CategoryId= 10, EanCode= "7707248566741", Description= "Rompecabezas de 500 piezas",  Price= 15000,  Unit= "Unidad"},
            new Product() {Id= 114, CategoryId= 10, EanCode= "7707248568899", Description= "Peluche de unicornio",  Price= 10000,  Unit= "Unidad"},
            new Product() {Id= 115, CategoryId= 10, EanCode= "7707248571851", Description= "Set de pintura y dibujo para niños",  Price= 20000,  Unit= "Unidad"},
            new Product() {Id= 116, CategoryId= 10, EanCode= "7707248573138", Description= "Libro para colorear de Disney",  Price= 5000,  Unit= "Unidad"},
            new Product() {Id= 117, CategoryId= 10, EanCode= "7707248573688", Description= "Juguete de dinosaurio T-Rex",  Price= 15000,  Unit= "Unidad"},
            new Product() {Id= 118, CategoryId= 10, EanCode= "7707248579215", Description= "Pelota de fútbol",  Price= 10000,  Unit= "Unidad"},
            new Product() {Id= 119, CategoryId= 10, EanCode= "7707248581799", Description= "Juego de cocina de juguete",  Price= 30000,  Unit= "Unidad"},
            new Product() {Id= 120, CategoryId= 10, EanCode= "7707248590418", Description= "Trompo de madera",  Price= 8000,  Unit= "Unidad"},
            new Product() {Id= 121, CategoryId= 11, EanCode= "7707248612165", Description= "Bolsa de alimento para perro marca Pedigree",  Price= 30000,  Unit= "Bolsa de 7.5 kg"},
            new Product() {Id= 122, CategoryId= 11, EanCode= "7707248620580", Description= "Bolsa de alimento para gato marca Whiskas",  Price= 20000,  Unit= "Bolsa de 2 kg"},
            new Product() {Id= 123, CategoryId= 11, EanCode= "7707248621204", Description= "Juguete para perro de peluche",  Price= 8000,  Unit= "Unidad"},
            new Product() {Id= 124, CategoryId= 11, EanCode= "7707248626056", Description= "Juguete para gato de cuerda",  Price= 5000,  Unit= "Unidad"},
            new Product() {Id= 125, CategoryId= 11, EanCode= "7707248627244", Description= "Cama para mascota tamaño mediano",  Price= 50000,  Unit= "Unidad"},
            new Product() {Id= 126, CategoryId= 11, EanCode= "7707248629408", Description= "Collar para perro ajustable",  Price= 15000,  Unit= "Unidad"},
            new Product() {Id= 127, CategoryId= 11, EanCode= "7707248631371", Description= "Correa para perro de cuero",  Price= 20000,  Unit= "Unidad"},
            new Product() {Id= 128, CategoryId= 11, EanCode= "7707248631388", Description= "Arena para gato marca Tidy Cats",  Price= 10000,  Unit= "Bolsa de 4 kg"},
            new Product() {Id= 129, CategoryId= 11, EanCode= "7707248638172", Description= "Peine para pelo de mascota",  Price= 8000,  Unit= "Unidad"},
            new Product() {Id= 130, CategoryId= 11, EanCode= "7707248642117", Description= "Champú para perro marca Hartz",  Price= 6000,  Unit= "Botella de 18 oz"},
            new Product() {Id= 131, CategoryId= 11, EanCode= "7707248642278", Description= "Arena de sílice para gato",  Price= 12000,  Unit= "Bolsa de 3.8 L"},
            new Product() {Id= 132, CategoryId= 11, EanCode= "7707248642377", Description= "Comedero para mascota con base antideslizante",  Price= 12000,  Unit= "Unidad"},
            new Product() {Id= 133, CategoryId= 12, EanCode= "7707248642940", Description= "Zapatos de tacón alto de cuero para mujer",  Price= 80000,  Unit= "Par"},
            new Product() {Id= 134, CategoryId= 12, EanCode= "7707248654561", Description= "Botas de invierno impermeables para hombre",  Price= 120000,  Unit= "Par"},
            new Product() {Id= 135, CategoryId= 12, EanCode= "7707248655698", Description= "Sandalias de playa para mujer",  Price= 30000,  Unit= "Par"},
            new Product() {Id= 136, CategoryId= 12, EanCode= "7707248656152", Description= "Zapatillas deportivas para correr para hombre",  Price= 70000,  Unit= "Par"},
            new Product() {Id= 137, CategoryId= 12, EanCode= "7707248657364", Description= "Zapatos de vestir de cuero para hombre",  Price= 90000,  Unit= "Par"},
            new Product() {Id= 138, CategoryId= 12, EanCode= "7707248673159", Description= "Zapatos planos de ballet para mujer",  Price= 40000,  Unit= "Par"},
            new Product() {Id= 139, CategoryId= 12, EanCode= "7707248677379", Description= "Botines de cuero con cordones para hombre",  Price= 100000,  Unit= "Par"},
            new Product() {Id= 140, CategoryId= 12, EanCode= "7707248681277", Description= "Zapatos de tacón bajo de charol para mujer",  Price= 60000,  Unit= "Par"},
            new Product() {Id= 141, CategoryId= 12, EanCode= "7707248696363", Description= "Zapatillas de deporte para mujer",  Price= 50000,  Unit= "Par"},
            new Product() {Id= 142, CategoryId= 12, EanCode= "7707248700633", Description= "Zapatos casuales de lona para hombre",  Price= 35000,  Unit= "Par"},
            new Product() {Id= 143, CategoryId= 12, EanCode= "7707248703382", Description= "Botas de cuero con hebilla para mujer",  Price= 70000,  Unit= "Par"},
            new Product() {Id= 144, CategoryId= 12, EanCode= "7707248708103", Description= "Zapatos de tacón medio de ante para mujer",  Price= 70000,  Unit= "Par"}
        };

        return products;
    }


    private Product CreateProduct(Product product)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}", Method.Post);
        //request.AddJsonBody(product);

        //var response =  _restClient.PostAsync(request);

        //Product? data = JsonConvert.DeserializeObject<Product>(response.Content!);

        //return data!;
    }

    private Product EditProduct(Product product)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{product.Id}", Method.Put);
        //request.AddJsonBody(product);

        //var response =  _restClient.PutAsync(request);

        //Product? data = JsonConvert.DeserializeObject<Product>(response.Content!);

        //return data!;
    }

    private List<Product> GetAllProducts()
    {
        return productList;
        //var request = new RestRequest($"{baseUrl}/{resourceName}", Method.Get);
        //var response =  _restClient.GetAsync(request);

        //List<Product>? data = JsonConvert.DeserializeObject<List<Product>>(response.Content!);

        //return data!;
    }

    private Product GetProductById(int id)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{id}", Method.Get);

        //var response =  _restClient.GetAsync(request);

        //Product? data = JsonConvert.DeserializeObject<Product>(response.Content!);

        //return data!;
    }

    private List<Product> GetProductsByPage(int page, int limit)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}?_page={page}&_limit={limit}", Method.Get);
        //var response =  _restClient.GetAsync(request);

        //List<Product>? data = JsonConvert.DeserializeObject<List<Product>>(response.Content!);

        //return data!;
    }

    private bool RemoveProduct(int id)
    {
        throw new NotImplementedException();

        //var request = new RestRequest($"{baseUrl}/{resourceName}/{id}", Method.Delete);

        //var response =  _restClient.DeleteAsync(request);

        //return response.IsSuccessStatusCode;
    }

    #endregion Private-Methods
}