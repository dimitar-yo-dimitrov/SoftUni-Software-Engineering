   USE CigarShop

-- 02.Insert

	  INSERT
		INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
	  VALUES 
			 ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg')
		   , ('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg')
		   , ('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg')
		   , ('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg')
		   , ('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

	  INSERT
		INTO Addresses(Town, Country, Streat, ZIP)
	  VALUES 
			 ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000)
		   , ('Athens', 'Greece', '4342 McDonald Avenue', 10435)
		   , ('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

-- 03.Update

      UPDATE Cigars
	     SET PriceForSingleCigar *= 1.20
	    FROM Cigars AS c
		JOIN Tastes AS t
		  ON c.TastId = t.Id 
       WHERE t.TasteType = 'Spicy'

	  UPDATE Brands
	     SET BrandDescription = 'New description'
	    FROM Brands AS b
   LEFT JOIN Cigars AS c
		  ON c.BrandId = b.Id
       WHERE b.BrandDescription IS NULL

-- 04.Delete

      DELETE c
	    FROM Clients AS c
		JOIN Addresses AS a
		  ON c.AddressId = a.Id
	   WHERE LEFT(Country, 1) = 'C'

      DELETE 
	    FROM Addresses
	   WHERE LEFT(Country, 1) = 'C'