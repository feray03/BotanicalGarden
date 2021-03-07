USE BotanicalGarden;
GO
INSERT INTO Seasons(Name)
VALUES ('spring'),
       ('summer'),
	   ('autumn'),
	   ('winter');

INSERT INTO Flowers(Name, Color, LifeExpectancy, SeasonsId)
VALUES ('Orchid', 'multicolored', 'perennials', 1),
       ('Tulip', 'multicolored', 'perennials', 1),
	   ('Violets', 'multicolored', 'perennials', 2),
	   ('Snowdrop', 'white', 'perennials', 4),
	   ('Peony', 'multicolored', 'perennials', 1),
	   ('Hyacinth', 'multicolored', 'perennials', 1),
	   ('Edelweiss', 'white', 'perennials', 4),
	   ('Rose', 'multicolored', 'perennials', 1),
	   ('Cloves', 'multicolored', 'perennials', 2),
	   ('Crocus', 'multicolored', 'perennials', 3);

INSERT INTO Trees(Name ,Type ,Height ,StemDiameter ,SeasonsId)
VALUES ('Poplar', 'deciduous', 25, 4, 1),
       ('Willow', 'deciduous', 30, 1.5, 1),
	   ('Linden', 'deciduous', 40, 3, 2),
	   ('Oak', 'deciduous', 35, 2, 1),
	   ('Beech', 'deciduous', 30, 2, 1),
	   ('Spruce', 'coniferous', 50, 4, 1),
	   ('Palm tree', 'fan-shaped leaves', 60, 0.4, 2),
	   ('Birch', 'deciduous', 30, 0.4, 1),
	   ('Jujube', 'deciduous', 8, 0.5, 2),
	   ('Hornbeam', 'deciduous', 18, 0.3, 1);

INSERT INTO Shrubs(Name, Type, Height, LifeExpectancy, SeasonsId)
VALUES ('Raspberry', 'wild or cultivated', 2, 'perennials', 2),
       ('Blackberry', 'wild or cultivated', 2, 'perennials', 2),
	   ('Blueberry', 'wild or cultivated', 2, 'perennials', 2),
	   ('Lilac', 'wild or cultivated', 6, 'perennials', 1),
	   ('Boxwood', 'cultivated', 8, 'perennials', 3),
	   ('Shipka', 'wild or cultivated', 4, 'perennials', 1),
	   ('Winter jasmine', 'wild', 3, 'perennials', 4),
	   ('Calluna vulgaris', 'wild or cultivated', 1,'perennials', 2),
	   ('Berberis thunbergii', 'wild or cultivated', 1.5, 'perennials', 1),
	   ('Calycanthus', 'wild or cultivated', 4, 'perennials', 3);

INSERT INTO Cactuses(Name, Height, Thorns, SeasonsId)
VALUES ('Mamilaration', 0.12, 'multifarious', 3),
       ('Ferrocactus', 1, 'flat thorns', 2),
	   ('Christmas carols', 0.25, 'no thorns', 4),
	   ('Echinopsis pachanoi', 6, 'yellow to brown', 1),
	   ('Cereus jamacaru', 6, 'yellow or white', 1),
	   ('Prickly pear', 5, 'green', 1),
	   ('Cephalocereus senilis', 15, 'thick thorns', 2),
	   ('Peyote', 0.2, 'no thorns', 1),
	   ('Astrophytum ornatum', 1, 'large spines, with a curved shape', 3),
	   ('Gymnocalycium', 0.2, 'rare thorns', 3);

INSERT INTO Grasses(Name, Height, SeasonsId)
VALUES ('Ryegrass', 0.06, 1),
       ('Pampas grass', 3, 1),
	   ('Troskot', 0.5, 2),
	   ('Miscanthus', 3, 4),
	   ('Imperata cylindrica', 3, 2),
	   ('Muhlenbergia capillaris', 0.9, 3),
	   ('Lemongrass', 0.14, 1),
	   ('Bambusa', 15, 1),
	   ('Lagurus ovatus', 0.3, 2),
	   ('Pennisetum alopecuroides', 1, 1);

SELECT * FROM Seasons
SELECT * FROM Flowers
SELECT * FROM Trees
SELECT * FROM Shrubs
SELECT * FROM Cactuses
SELECT * FROM Grasses