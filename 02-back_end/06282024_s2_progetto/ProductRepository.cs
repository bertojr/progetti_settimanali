namespace _06282024_s2_progetto
{
	public static class ProductRepository
	{
		private static List<Product> products = new List<Product>();
		static ProductRepository()
		{
			products.Add(new Product
			{
				id = 1,
				name = "Nike Mercurial Superfly 9 Elite",
				price = 279.99m,
				description = "Le scarpe Elite nascono per chi è ossessionato " +
				"dal gioco. Questa edizione speciale di Superfly 9 non fa " +
				"eccezione. Con il suo design Pastel Pink, sarà protagonista ai " +
				"piedi dei migliori giocatori del mondo mentre disputano i " +
				"tornei più importanti. Aggiungi un'unità Air Zoom appositamente " +
				"progettata per la velocità, ed ecco una scarpa da campioni " +
				"pronta per mostrare il tuo talento al mondo.",
				coverImage = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/216ff4ca-0012-46c7-baa0-80d6ec2084e1/scarpa-da-calcio-a-taglio-alto-fg-mercurial-superfly-9-elite-Vpvx79.png",
				additionalImage1 = "",
				additionalImage2 = "",

            });
		}

		public static List<Product> GetAllProducts()
		{
			return products;
		}
		public static Product GetProductById(int id)
		{
			return products.FirstOrDefault(product => product.id == id);
		}
		public static void AddProduct(Product newProduct)
		{
			products.Add(newProduct);
		}
	}
}

