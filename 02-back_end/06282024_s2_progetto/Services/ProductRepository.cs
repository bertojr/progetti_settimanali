namespace _06282024_s2_progetto.Models
{
	public static class ProductRepository
	{
		private static List<Product> products = new List<Product>();
		static ProductRepository()
		{
			products.Add(new Product
			{
				Id = 1,
				Name = "Nike Mercurial Superfly 9 Elite",
				Price = 279.99m,
				Description = "Le scarpe Elite nascono per chi è ossessionato " +
				"dal gioco. Questa edizione speciale di Superfly 9 non fa " +
				"eccezione. Con il suo design Pastel Pink, sarà protagonista ai " +
				"piedi dei migliori giocatori del mondo mentre disputano i " +
				"tornei più importanti. Aggiungi un'unità Air Zoom appositamente " +
				"progettata per la velocità, ed ecco una scarpa da campioni " +
				"pronta per mostrare il tuo talento al mondo.",
				CoverImage = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/216ff4ca-0012-46c7-baa0-80d6ec2084e1/scarpa-da-calcio-a-taglio-alto-fg-mercurial-superfly-9-elite-Vpvx79.png",
				AdditionalImage1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f62ae579-a690-4fea-a115-b1450a6b49f2/scarpa-da-calcio-a-taglio-alto-fg-mercurial-superfly-9-elite-Vpvx79.png",
				AdditionalImage2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f2bbc910-4adc-45ca-abce-19ab5571b9ee/scarpa-da-calcio-a-taglio-alto-fg-mercurial-superfly-9-elite-Vpvx79.png",
            });
		}

		public static List<Product> GetAllProducts()
		{
			return products;
		}
		public static Product GetProductById(int id)
		{
			return products.FirstOrDefault(product => product.Id == id);
		}
		public static void Delete(int id)
		{
			var product = GetProductById(id);
			if(product != null)
			{
				products.Remove(product);
			}
			
		}
		public static void AddProduct(Product newProduct)
		{
			products.Add(newProduct);
		}
	}
}

