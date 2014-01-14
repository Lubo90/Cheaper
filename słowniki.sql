use Cheaper;

-- POPULACJA STRUKTUR SŁOWNIKOWYCH DANYMI

INSERT INTO Categories(Name)
	SELECT 'Artykuły gospodarstwa domowego'
	UNION SELECT 'RTV'
	UNION SELECT 'Słodycze'
	UNION SELECT 'Owoce'
	UNION SELECT 'Warzywa'
	UNION SELECT 'Fastfood'
	UNION SELECT 'Elektronika';