-- ============================================================
--  PyroFetes – Jeu de données complet
--  Compatible SQL Server / EF Core
--  Ordre d'insertion respectant les contraintes FK
-- ============================================================

-- -------------------------------------------------------
-- 1. Settings
-- -------------------------------------------------------
INSERT INTO Settings ( Logo, ElectronicSignature) VALUES
    ( 'assets/logo_pyrofetes.png', 'assets/signature_direction.png');

-- -------------------------------------------------------
-- 2. Cities
-- -------------------------------------------------------
INSERT INTO Cities ( Name, ZipCode) VALUES
                                        ( 'Paris',        75001),
                                        (  'Lyon',         69001),
                                        (  'Marseille',    13001),
                                        ('Bordeaux',     33000),
                                        ( 'Strasbourg',   67000),
                                        ( 'Nantes',       44000),
                                        ('Toulouse',     31000),
                                        (  'Lille',        59000),
                                        (  'Nice',         06000),
                                        ('Montpellier',  34000);

-- -------------------------------------------------------
-- 3. Classifications
-- -------------------------------------------------------
INSERT INTO Classifications ( Label) VALUES
                                         ('F1 – Faible danger'),
                                         ( 'F2 – Danger moyen'),
                                         ( 'F3 – Danger élevé'),
                                         ( 'F4 – Usage professionnel'),
                                         ( 'T1 – Théâtral usage général'),
                                         ( 'T2 – Théâtral usage professionnel');

-- -------------------------------------------------------
-- 4. ProductCategories
-- -------------------------------------------------------
INSERT INTO ProductCategories ( Label) VALUES
                                           ( 'Bouquet final'),
                                           ( 'Chandelle romaine'),
                                           ( 'Fontaine'),
                                           ( 'Fusée'),
                                           ( 'Mine'),
                                           ( 'Pétard'),
                                           ( 'Torche'),
                                           ( 'Batterie'),
                                           ( 'Cascades'),
                                           ( 'Lanceur électrique');

-- -------------------------------------------------------
-- 5. Colors
-- -------------------------------------------------------
INSERT INTO Colors ( Label) VALUES
                                (  'Rouge'),
                                (  'Vert'),
                                (  'Bleu'),
                                (  'Or'),
                                (  'Argent'),
                                (  'Blanc'),
                                (  'Orange'),
                                (  'Violet'),
                                ( 'Rose'),
                                ( 'Multicolore');

-- -------------------------------------------------------
-- 6. Effects
-- -------------------------------------------------------
INSERT INTO Effects ( Label) VALUES
                                 (  'Craquement'),
                                 (  'Sifflement'),
                                 (  'Scintillement'),
                                 (  'Pluie dorée'),
                                 (  'Bouquet étoilé'),
                                 (  'Palmier'),
                                 (  'Chrysanthème'),
                                 (  'Peony'),
                                 (  'Comet'),
                                 ( 'Strobe'),
                                 ( 'Nishiki Kamuro'),
                                 ('Pistil');

-- -------------------------------------------------------
-- 7. Movements (avant Products car FK)
-- -------------------------------------------------------
INSERT INTO Movements ( Date, Start, Arrival, Quantity, SourceWarehouseId, DestinationWarehouseId) VALUES
                                                                                                       ('2024-01-10 08:00:00', '2024-01-10 08:00:00', '2024-01-10 14:00:00', 200, NULL, 1),
                                                                                                       ( '2024-02-15 09:00:00', '2024-02-15 09:00:00', '2024-02-15 16:30:00', 150, NULL, 2),
                                                                                                       ('2024-03-01 07:30:00', '2024-03-01 07:30:00', '2024-03-01 12:00:00', 80,  1,    3),
                                                                                                       ( '2024-04-20 10:00:00', '2024-04-20 10:00:00', '2024-04-20 18:00:00', 300, 2,    1),
                                                                                                       ( '2024-05-05 08:00:00', '2024-05-05 08:00:00', '2024-05-05 15:00:00', 120, 3,    2),
                                                                                                       ('2024-06-14 06:00:00', '2024-06-14 06:00:00', '2024-06-14 10:00:00', 500, 1,    NULL),
                                                                                                       ( '2024-07-04 07:00:00', '2024-07-04 07:00:00', '2024-07-04 11:00:00', 250, 2,    NULL),
                                                                                                       ( '2024-08-12 09:00:00', '2024-08-12 09:00:00', '2024-08-12 17:00:00', 180, NULL, 3);

-- -------------------------------------------------------
-- 8. Products
-- -------------------------------------------------------
INSERT INTO Products ( Reference, Name, Duration, Caliber, ApprovalNumber, Weight, Nec, Image, Link, MinimalQuantity, ClassificationId, ProductCategoryId, MovementId) VALUES
                                                                                                                                                                           (  'PYR-001', 'Bouquet Tricolore 30T',     45.5,  30, 'APP-2023-001', 1.200, 0.850, 'products/bouquet_tricolore.jpg',  'https://catalogue.pyrofetes.fr/PYR-001', 10, 4, 1, 1),
                                                                                                                                                                           (  'PYR-002', 'Chandelle Or 25T',          30.0,  25, 'APP-2023-002', 0.800, 0.560, 'products/chandelle_or.jpg',       'https://catalogue.pyrofetes.fr/PYR-002', 20, 3, 2, 2),
                                                                                                                                                                           (  'PYR-003', 'Fontaine Argentée 20T',     60.0,  20, 'APP-2023-003', 0.500, 0.300, 'products/fontaine_arg.jpg',       'https://catalogue.pyrofetes.fr/PYR-003', 15, 2, 3, 3),
                                                                                                                                                                           ( 'PYR-004', 'Fusée Palmier 50T',         25.0,  50, 'APP-2023-004', 2.500, 1.800, 'products/fusee_palmier.jpg',      'https://catalogue.pyrofetes.fr/PYR-004',  5, 4, 4, 4),
                                                                                                                                                                           ( 'PYR-005', 'Mine Chrysanthème 75T',     15.0,  75, 'APP-2023-005', 3.200, 2.400, 'products/mine_chrysantheme.jpg',  'https://catalogue.pyrofetes.fr/PYR-005',  5, 4, 5, 5),
                                                                                                                                                                           (  'PYR-006', 'Batterie Festival 100T',   120.0, 100, 'APP-2023-006', 8.000, 5.600, 'products/batterie_festival.jpg', 'https://catalogue.pyrofetes.fr/PYR-006',  3, 4, 8, 6),
                                                                                                                                                                           (  'PYR-007', 'Torche Colorée 15T',        90.0,  15, 'APP-2023-007', 0.300, 0.180, 'products/torche_coloree.jpg',    'https://catalogue.pyrofetes.fr/PYR-007', 30, 2, 7, 7),
                                                                                                                                                                           (  'PYR-008', 'Cascade Dorée 40T',         75.0,  40, 'APP-2023-008', 1.800, 1.200, 'products/cascade_doree.jpg',     'https://catalogue.pyrofetes.fr/PYR-008', 10, 4, 9, 8),
                                                                                                                                                                           (  'PYR-009', 'Peony Multicolore 60T',     30.0,  60, 'APP-2023-009', 4.500, 3.200, 'products/peony_multi.jpg',       'https://catalogue.pyrofetes.fr/PYR-009',  5, 4, 1, 1),
                                                                                                                                                                           ( 'PYR-010', 'Lanceur 36 Tirs EL',         0.0,   0, 'APP-2023-010', 2.100, 0.000, 'products/lanceur_36.jpg',        'https://catalogue.pyrofetes.fr/PYR-010',  2, 6, 10,2),
                                                                                                                                                                           ( 'PYR-011', 'Strobe Blanc Intense 25T',  45.0,  25, 'APP-2023-011', 0.900, 0.650, 'products/strobe_blanc.jpg',      'https://catalogue.pyrofetes.fr/PYR-011', 10, 3, 3, 3),
                                                                                                                                                                           ( 'PYR-012', 'Comet Violet 30T',          20.0,  30, 'APP-2023-012', 1.100, 0.800, 'products/comet_violet.jpg',      'https://catalogue.pyrofetes.fr/PYR-012', 12, 3, 4, 4);

-- -------------------------------------------------------
-- 9. Brands
-- -------------------------------------------------------
INSERT INTO Brands ( Name, ProductId) VALUES
                                          ( 'PyroMaster',   1),
                                          (  'GoldFlame',    1),
                                          (  'ArtificePlus', 2),
                                          (  'ArtificePlus', 3),
                                          (  'StarBurst',    4),
                                          (  'StarBurst',    5),
                                          ( 'FestivalFire', 6),
                                          (  'TorchCo',      7),
                                          ( 'GoldFlame',    8),
                                          ( 'PyroMaster',   9),
                                          ( 'ElecFire',     10),
                                          ( 'PyroMaster',   11),
                                          ( 'StarBurst',    12);

-- -------------------------------------------------------
-- 10. ProductColors
-- -------------------------------------------------------
INSERT INTO ProductColors (ProductId, ColorId) VALUES
                                                   (1,  1), (1,  3), (1,  6),  -- Bouquet Tricolore : rouge, bleu, blanc
                                                   (2,  4),                     -- Chandelle Or
                                                   (3,  5),                     -- Fontaine Argentée
                                                   (4,  4), (4,  2),            -- Fusée Palmier : or, vert
                                                   (5,  7), (5,  4),            -- Mine Chrysanthème : orange, or
                                                   (6,  10),                    -- Batterie Festival : multicolore
                                                   (7,  1), (7,  2), (7,  3),  -- Torche : rouge, vert, bleu
                                                   (8,  4), (8,  5),            -- Cascade Dorée : or, argent
                                                   (9,  10),                    -- Peony Multicolore
                                                   (11, 6),                     -- Strobe Blanc
                                                   (12, 8);                     -- Comet Violet

-- -------------------------------------------------------
-- 11. ProductEffects
-- -------------------------------------------------------
INSERT INTO ProductEffects (ProductId, EffectId) VALUES
                                                     (1,  5), (1,  8),   -- Bouquet : bouquet étoilé, peony
                                                     (2,  4), (2,  3),   -- Chandelle Or : pluie dorée, scintillement
                                                     (3,  3),            -- Fontaine : scintillement
                                                     (4,  6), (4,  9),   -- Fusée Palmier : palmier, comet
                                                     (5,  7), (5,  1),   -- Mine : chrysanthème, craquement
                                                     (6,  5), (6,  7), (6, 10), -- Batterie : bouquet, chrysanthème, strobe
                                                     (7,  3), (7,  2),   -- Torche : scintillement, sifflement
                                                     (8,  4), (8,  11),  -- Cascade : pluie dorée, Nishiki
                                                     (9,  8), (9,  12),  -- Peony : peony, pistil
                                                     (11, 10),           -- Strobe
                                                     (12, 9);            -- Comet

-- -------------------------------------------------------
-- 12. Warehouses
-- -------------------------------------------------------
INSERT INTO Warehouses ( Name, MaxWeight, [Current], MinWeight, Address, ZipCode, City) VALUES
                                                                                            ( 'Entrepôt Central Paris',    50000, 18500, 5000, '12 rue de la Pyrotechnie',  '75019', 'Paris'),
                                                                                            ( 'Dépôt Sud Marseille',       30000, 12000, 3000, '8 avenue du Port Sec',      '13016', 'Marseille'),
                                                                                            ( 'Stockage Est Strasbourg',   20000,  8200, 2000, '5 chemin des Entrepôts',    '67200', 'Strasbourg'),
                                                                                            ( 'Site Ouest Nantes',         25000,  6500, 2500, '22 zone industrielle Ouest','44800', 'Nantes');

-- -------------------------------------------------------
-- 13. WarehouseProducts
-- -------------------------------------------------------
INSERT INTO WarehouseProducts (ProductId, WarehouseId, Quantity) VALUES
                                                                     (1,  1, 120), (1,  2,  60),
                                                                     (2,  1, 200), (2,  3,  80),
                                                                     (3,  1, 150), (3,  4,  90),
                                                                     (4,  1,  40), (4,  2,  25),
                                                                     (5,  1,  30), (5,  2,  15),
                                                                     (6,  1,  20), (6,  3,  10),
                                                                     (7,  2, 300), (7,  4, 180),
                                                                     (8,  1,  75), (8,  2,  50),
                                                                     (9,  1,  35),
                                                                     (10, 1,  18), (10, 3,  12),
                                                                     (11, 2,  60),
                                                                     (12, 3,  45);

-- -------------------------------------------------------
-- 14. Materials
-- -------------------------------------------------------
INSERT INTO Materials ( Name, Quantity, WarehouseId) VALUES
                                                         ( 'Câble électrique 50m',     40,  1),
                                                         ( 'Détonateur électrique',   500,  1),
                                                         ( 'Bouchon sécurité rouge',  300,  1),
                                                         ( 'Trépied aluminium',        25,  2),
                                                         ( 'Tuyau métallique 1m',      80,  2),
                                                         ( 'Boitier de tir 36 sorties', 10, 1),
                                                         ( 'Rallonge 10m IP67',         60, 3),
                                                         ( 'Mortier plastique 50mm',   200, 3),
                                                         ( 'Mortier acier 75mm',       100, 1),
                                                         ('Tableau de tir 100 CH',      5, 4),
                                                         ( 'Caisse de transport étanche',30, 2),
                                                         ( 'Lunettes de protection',    50, 1);

-- -------------------------------------------------------
-- 15. MaterialWarehouses
-- -------------------------------------------------------
INSERT INTO MaterialWarehouses (MaterialId, WarehouseId) VALUES
                                                             (1, 1), (1, 3),
                                                             (2, 1), (2, 2),
                                                             (3, 1),
                                                             (4, 2), (4, 4),
                                                             (5, 2), (5, 3),
                                                             (6, 1), (6, 4),
                                                             (7, 3),
                                                             (8, 3), (8, 1),
                                                             (9, 1),
                                                             (10, 4),
                                                             (11, 2),
                                                             (12, 1), (12, 2);

-- -------------------------------------------------------
-- 16. Suppliers
-- -------------------------------------------------------
INSERT INTO Suppliers ( Name, Email, Phone, Address, ZipCode, City, DeliveryDelay) VALUES
                                                                                       ('Pyrotechnie Ruggieri',      'commandes@ruggieri.fr',       '01 47 00 11 22', '14 avenue de la Fête',    '75015', 'Paris',       7),
                                                                                       ( 'Lacroix Défense Feux',      'pro@lacroix-feux.com',        '04 78 92 00 10', '3 zone industrielle Nord','69130', 'Lyon',        10),
                                                                                       ( 'Jorge Banus Pyro',          'info@jorgebanus-pyro.es',     '+34 952 810 000','Pol. Ind. Las Maravillas', '29600', 'Marbella',    21),
                                                                                       ('Brother Pyro Import',       'sales@brotherpyro.com',       '+1 555 010 2020','1200 Fireworks Blvd',     '30301', 'Atlanta',     30),
                                                                                       ( 'Nico Pyrotechnie',          'achats@nico-pyro.fr',         '04 91 25 36 47', '27 impasse des Artifices','13010', 'Marseille',   5),
                                                                                       ( 'Surex Pyrotechnie',         'contact@surex.fr',            '03 90 00 12 34', '10 rue Gutenberg',        '67600', 'Sélestat',    6);

-- -------------------------------------------------------
-- 17. Prices (Product x Supplier)
-- -------------------------------------------------------
INSERT INTO Prices (ProductId, SupplierId, SellingPrice) VALUES
                                                             (1, 1, 12.50), (1, 2, 13.00),
                                                             (2, 1,  6.80), (2, 5,  7.20),
                                                             (3, 1,  4.50), (3, 5,  4.80),
                                                             (4, 2, 28.00), (4, 3, 26.50),
                                                             (5, 2, 35.00), (5, 3, 33.00),
                                                             (6, 1, 95.00), (6, 2, 98.50),
                                                             (7, 5,  3.20), (7, 6,  3.50),
                                                             (8, 1, 22.00), (8, 2, 23.50),
                                                             (9, 2, 42.00), (9, 4, 39.00),
                                                             (10,1, 185.00),(10,6, 190.00),
                                                             (11,5,  8.90), (11,6,  9.20),
                                                             (12,3, 14.00), (12,4, 13.50);

-- -------------------------------------------------------
-- 18. Deliverers
-- -------------------------------------------------------
INSERT INTO Deliverers ( Transporter) VALUES
                                          ( 'Chronopost Marchandises Dangereuses'),
                                          ( 'DHL Fret Spécial'),
                                          ( 'TNT Express ADR'),
                                          ('Transport Pyro Interne'),
                                          ( 'Geodis Fret');

-- -------------------------------------------------------
-- 19. DeliveryNotes
-- -------------------------------------------------------
INSERT INTO DeliveryNotes (TrackingNumber, DelivererId, EstimateDeliveryDate, ExpeditionDate, RealDeliveryDate) VALUES
                                                                                                                    ('CPM-2024-001234', 1, '2024-01-12', '2024-01-09', '2024-01-12'),
                                                                                                                    ( 'DHL-2024-005678', 2, '2024-02-18', '2024-02-14', '2024-02-17'),
                                                                                                                    ( 'TNT-2024-009012', 3, '2024-03-05', '2024-03-01', '2024-03-06'),
                                                                                                                    ('INT-2024-000001', 4, '2024-04-22', '2024-04-20', '2024-04-22'),
                                                                                                                    ( 'GEO-2024-001111', 5, '2024-05-10', '2024-05-07', NULL);

-- -------------------------------------------------------
-- 20. ProductDeliveries
-- -------------------------------------------------------
INSERT INTO ProductDeliveries (ProductId, DeliveryNoteId, Quantity) VALUES
                                                                        (1, 1, 60),  (2, 1, 100),
                                                                        (3, 2, 80),  (4, 2, 20),
                                                                        (5, 3, 15),  (6, 3, 8),
                                                                        (7, 4, 150), (8, 4, 40),
                                                                        (9, 5, 30),  (10,5, 6);

-- -------------------------------------------------------
-- 21. PurchaseOrders
-- -------------------------------------------------------
INSERT INTO PurchaseOrders ( PurchaseConditions, SupplierId) VALUES
                                                                 ('Paiement à 30 jours – transport inclus – palette EUR 80x120', 1),
                                                                 ('Paiement à 60 jours – Incoterm EXW Lyon – assurance acheteur', 2),
                                                                 ('Paiement anticipé -2% – transport DDP Paris – emballage ADR inclus', 5),
                                                                 ('Paiement à 45 jours – transport à la charge du vendeur jusqu au dépôt', 3),
                                                                 ( 'Paiement à 30 jours – transport maritime consolidé', 4);

-- -------------------------------------------------------
-- 22. PurchaseProducts
-- -------------------------------------------------------
INSERT INTO PurchaseProducts (ProductId, PurchaseOrderId, Quantity) VALUES
                                                                        (1, 1, 200), (2, 1, 300), (3, 1, 150),
                                                                        (4, 2,  50), (5, 2,  30), (6, 2,  20),
                                                                        (7, 3, 500), (8, 3, 100),
                                                                        (9, 4,  40),(10, 4,  15),
                                                                        (11,5, 100),(12, 5,  80);

-- -------------------------------------------------------
-- 23. ProviderTypes
-- -------------------------------------------------------
INSERT INTO ProviderTypes ( Label) VALUES
                                       ( 'Sonorisation'),
                                       ('Éclairage scénique'),
                                       ( 'Sécurité / Protection'),
                                       ( 'Logistique & Transport'),
                                       ( 'Location de matériel'),
                                       ( 'Médical / Secours');

-- -------------------------------------------------------
-- 24. ServiceProviders
-- -------------------------------------------------------
INSERT INTO ServiceProviders ( Price, ProviderTypeId) VALUES
                                                          ( 4500.00, 1),
                                                          (3200.00, 1),
                                                          (5800.00, 2),
                                                          (2800.00, 3),
                                                          (7500.00, 3),
                                                          ( 1200.00, 4),
                                                          (73500.00, 5),
                                                          ( 900.00, 6);

-- -------------------------------------------------------
-- 25. CustomerTypes
-- -------------------------------------------------------
INSERT INTO CustomerTypes ( Label) VALUES
                                       ( 'Mairie / Collectivité'),
                                       ( 'Association'),
                                       ( 'Entreprise privée'),
                                       ( 'Particulier'),
                                       ( 'Organisateur d événements');

-- -------------------------------------------------------
-- 26. Customers


-- -------------------------------------------------------
-- 27. Contacts
-- -------------------------------------------------------



-- -------------------------------------------------------
-- 31. QuotationProducts
-- -------------------------------------------------------
INSERT INTO QuotationProducts (ProductId, QuotationId, Quantity) VALUES
                                                                     (1, 1, 80), (4, 1, 30), (5, 1, 20), (6, 1, 5),  (8, 1, 40),
                                                                     (2, 2, 50), (3, 2, 40), (7, 2, 80),
                                                                     (1, 3, 40), (6, 3, 3),  (9, 3, 15),
                                                                     (1, 4, 60), (4, 4, 20), (6, 4, 4),  (7, 4,100),
                                                                     (1, 5, 70), (5, 5, 15), (8, 5, 30),
                                                                     (2, 6, 60), (3, 6, 50), (7, 6, 90);

-- -------------------------------------------------------
-- 32. Staff
-- -------------------------------------------------------
INSERT INTO Staffs ( FirstName, LastName, Profession, Email, F4T2NumberApproval, F4T2ExpirationDate) VALUES
                                                                                                         (  'Antoine',   'Duval',    'Chef artificier',           'a.duval@pyrofetes.fr',      'F4-2021-00142', '2025-12-31'),
                                                                                                         (  'Camille',   'Renard',   'Artificier',                'c.renard@pyrofetes.fr',     'F4-2022-00255', '2026-06-30'),
                                                                                                         (  'Nicolas',   'Lefort',   'Artificier',                'n.lefort@pyrofetes.fr',     'F4-2020-00387', '2024-12-31'),
                                                                                                         (  'Emma',      'Vidal',    'Technicien pyrotechnie',    'e.vidal@pyrofetes.fr',      'T2-2023-00104', '2027-03-31'),
                                                                                                         (  'Julien',    'Moreau',   'Chef de chantier',          'j.moreau@pyrofetes.fr',     'F4-2021-00521', '2025-09-30'),
                                                                                                         (  'Laura',     'Blanc',    'Artificière',               'l.blanc@pyrofetes.fr',      'F4-2022-00698', '2026-12-31'),
                                                                                                         (  'Pierre',    'Garnier',  'Technicien électronique',   'p.garnier@pyrofetes.fr',    'T2-2021-00789', '2025-11-30'),
                                                                                                         (  'Marie',     'Lefebvre', 'Responsable sécurité',      'm.lefebvre@pyrofetes.fr',   'F4-2023-00901', '2027-06-30'),
                                                                                                         (  'Hugo',      'Simon',    'Artificier junior',         'h.simon@pyrofetes.fr',      'T1-2023-01023', '2025-06-30'),
                                                                                                         ( 'Pauline',   'Robert',   'Coordinatrice logistique',  'p.robert@pyrofetes.fr',     'T2-2022-01145', '2026-09-30');

-- -------------------------------------------------------
-- 33. ExperienceLevels
-- -------------------------------------------------------
INSERT INTO ExperienceLevels ( Label, StaffId) VALUES
                                                   (  'Expert – +15 ans',         1),
                                                   (  'Confirmé – 8 ans',         2),
                                                   (  'Confirmé – 6 ans',         3),
                                                   (  'Intermédiaire – 3 ans',    4),
                                                   (  'Expert – +12 ans',         5),
                                                   (  'Confirmé – 7 ans',         6),
                                                   (  'Intermédiaire – 4 ans',    7),
                                                   (  'Confirmé – 5 ans',         8),
                                                   (  'Débutant – 1 an',          9),
                                                   ( 'Intermédiaire – 3 ans',   10);

-- -------------------------------------------------------
-- 34. HistoryOfApprovals
-- -------------------------------------------------------
INSERT INTO HistoryOfApprovals ( DeliveryDate, ExpirationDate) VALUES
                                                                   ( '2021-03-15', '2025-12-31'),
                                                                   ( '2022-06-01', '2026-06-30'),
                                                                   ( '2020-09-10', '2024-12-31'),
                                                                   ( '2023-01-20', '2027-03-31'),
                                                                   ( '2021-09-05', '2025-09-30'),
                                                                   ( '2022-12-15', '2026-12-31'),
                                                                   ( '2021-11-01', '2025-11-30'),
                                                                   ( '2023-06-10', '2027-06-30'),
                                                                   ( '2019-03-15', '2021-03-14'),  -- expirée (historique)
                                                                   ('2023-09-01', '2026-09-30');

-- -------------------------------------------------------
-- 35. StaffHistoryOfApprovals
-- -------------------------------------------------------
INSERT INTO StaffHistoryOfApprovals (StaffId, HistoryOfApprovalId) VALUES
                                                                       (1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
                                                                       (6, 6), (7, 7), (8, 8), (9, 9), (10,10),
                                                                       (3, 1); -- Nicolas a eu une précédente approbation

-- -------------------------------------------------------
-- 36. Availabilities
-- -------------------------------------------------------
INSERT INTO Availabilities (AvailabilityDate, DeliveryDate, ExpirationDate, RenewallDate) VALUES
                                                                                              (  '2024-07-14', '2024-07-14', '2024-07-15', '2025-07-14'),
                                                                                              (  '2024-07-14', '2024-07-14', '2024-07-15', '2025-07-14'),
                                                                                              (  '2024-08-15', '2024-08-15', '2024-08-16', '2025-08-15'),
                                                                                              (  '2024-08-15', '2024-08-15', '2024-08-16', '2025-08-15'),
                                                                                              (  '2024-09-21', '2024-09-21', '2024-09-22', '2025-09-21'),
                                                                                              (  '2024-12-31', '2024-12-31', '2025-01-01', '2025-12-31'),
                                                                                              (  '2024-07-04', '2024-07-04', '2024-07-05', '2025-07-04'),
                                                                                              (  '2024-06-21', '2024-06-21', '2024-06-22', '2025-06-21');

-- -------------------------------------------------------
-- 37. StaffAvailabilities
-- -------------------------------------------------------
INSERT INTO StaffAvailabilities (StaffId, AvailabilityId) VALUES
                                                              (1, 1), (2, 1), (5, 1), (8, 1),   -- Paris 14 juillet
                                                              (1, 3), (3, 3), (6, 3), (7, 3),   -- Marseille 15 août
                                                              (2, 5), (4, 5), (9, 5),            -- Bordeaux
                                                              (1, 6), (2, 6), (5, 6), (10,6),   -- Nouvel an
                                                              (3, 7), (6, 7), (8, 7),            -- 4 juillet Lyon
                                                              (4, 8), (7, 8), (9, 8);            -- Fête musique

-- -------------------------------------------------------
-- 38. StaffContacts
-- -------------------------------------------------------
INSERT INTO StaffContacts (StaffId, ContactId) VALUES
                                                   (1, 1), (1, 2),
                                                   (2, 4),
                                                   (5, 6),
                                                   (6, 3),
                                                   (8, 5),
                                                   (10,8);

-- -------------------------------------------------------
-- 39. Trucks
-- -------------------------------------------------------
INSERT INTO Trucks ( Type, MaxExplosiveCapacity, Sizes, Status) VALUES
                                                                    ( 'Fourgon 20m³',          500.0,  '5.5m x 2.2m x 2.5m', 'Disponible'),
                                                                    ( 'Semi-remorque ADR 82m³',3000.0, '13.6m x 2.4m x 2.8m','Disponible'),
                                                                    ( 'Camion 40m³ frigorifié',1000.0, '7.2m x 2.4m x 2.6m', 'En maintenance'),
                                                                    ( 'Fourgon 15m³',           300.0, '4.2m x 2.0m x 2.2m', 'Disponible'),
                                                                    ( 'Pick-up plateau',         80.0, '2.0m x 1.8m x 0.5m', 'Disponible');

-- -------------------------------------------------------
-- 40. SoundCategories
-- -------------------------------------------------------
INSERT INTO SoundCategories (Name) VALUES
                                       ( 'Ouverture / Intro'),
                                       ( 'Corps de spectacle'),
                                       ( 'Bouquet final'),
                                       ( 'Transition'),
                                       ( 'Ambiance');

-- -------------------------------------------------------
-- 41. Sounds
-- -------------------------------------------------------
INSERT INTO Sounds ( Name, Type, Artist, Duration, Kind, Format, CreationDate, SoundCategoryId) VALUES
                                                                                                    (  '1812 Ouverture',             'Classique',    'Tchaïkovski',         900,  'Musique',  'WAV 48kHz 24bit', '2023-05-10', 1),
                                                                                                    ( 'La Marseillaise Orchestrale','Hymne',        'Berlioz arr.',        210,  'Musique',  'WAV 48kHz 24bit', '2023-05-10', 1),
                                                                                                    (  'Also Sprach Zarathustra',    'Classique',    'Richard Strauss',     480,  'Musique',  'WAV 48kHz 24bit', '2023-06-01', 1),
                                                                                                    (  'Fanfare Spectacle 01',       'Fanfare',      'Studio Pyro',          60,  'Jingle',   'WAV 44.1kHz',     '2024-01-15', 4),
                                                                                                    (  'Symphonie Feu & Lumière',    'Orchestral',   'Studio Pyro',        1200,  'Musique',  'WAV 48kHz 24bit', '2024-02-20', 2),
                                                                                                    (  'Rock the Fireworks',         'Rock',         'PyroRock Band',       780,  'Musique',  'MP3 320kbps',     '2023-09-05', 2),
                                                                                                    (  'Electronic Fire Mix',        'Électronique', 'DJ Pyro',             960,  'Mix',      'WAV 44.1kHz',     '2023-11-15', 2),
                                                                                                    (  'Finale Épique',              'Orchestral',   'Studio Pyro',         180,  'Musique',  'WAV 48kHz 24bit', '2024-01-15', 3),
                                                                                                    (  'Grand Finale 2024',          'Orchestral',   'Philharmonique Pyro', 240,  'Musique',  'WAV 48kHz 24bit', '2024-03-01', 3),
                                                                                                    ( 'Ambiance Nocturne',          'Ambient',      'Sound Design Studio', 600,  'Musique',  'WAV 44.1kHz',     '2023-07-20', 5);

-- -------------------------------------------------------
-- 42. Shows
-- -------------------------------------------------------
INSERT INTO Shows (Name, Place, Description, Date, PyrotechnicImplementationPlan, CityId) VALUES
                                                                                              ( 'Feux du 14 Juillet Paris 2024',      'Trocadéro – Tour Eiffel',     'Grand spectacle national – 30 minutes – 120 000 spectateurs',       '2024-07-14', 'plans/paris_14juillet_2024_v3.pdf',    1),
                                                                                              ( 'Festival Lumières Lyon 2024',        'Place Bellecour',             'Spectacle estival – 20 minutes – 50 000 spectateurs',               '2024-08-03', 'plans/lyon_festival_2024_v2.pdf',      2),
                                                                                              ( 'Fête Nationale Marseille 2024',      'Vieux-Port',                  'Show nautique et aérien – 25 minutes',                              '2024-07-14', 'plans/marseille_14juillet_2024_v1.pdf',3),
                                                                                              ('Gala Entreprise Paris 2024',         'Château de Versailles',       'Show privé soirée de gala – 15 minutes',                            '2024-09-21', 'plans/versailles_gala_2024_v2.pdf',    1),
                                                                                              ('Saint-Sylvestre Bordeaux 2024',      'Place de la Bourse',          'Feux du nouvel an – 20 minutes',                                    '2024-12-31', 'plans/bordeaux_sylvestre_2024_v1.pdf', 4),
                                                                                              ('Fête de la Musique Nantes 2024',     'Île de Nantes',               'Show pyrotechnique de clôture – 10 minutes',                        '2024-06-21', 'plans/nantes_musique_2024_v1.pdf',     6),
                                                                                              ( 'Inauguration Parc Strasbourg 2025',  'Parc de l Orangerie',        'Feux d\inauguration – 12 minutes',                                 '2025-04-15', 'plans/strasbourg_inaug_2025_v1.pdf',   5),
                                                                                              ('Feux Casino Nice 2024',              'Promenade des Anglais',       'Show prestige casino – 18 minutes',                                 '2024-11-01', 'plans/nice_casino_2024_v2.pdf',        9);

-- -------------------------------------------------------
-- 43. ShowStaffs
-- -------------------------------------------------------
INSERT INTO ShowStaffs (StaffId, ShowId) VALUES
                                             (1,1),(2,1),(5,1),(8,1),(7,1),
                                             (1,2),(3,2),(6,2),(10,2),
                                             (2,3),(4,3),(6,3),(8,3),
                                             (1,4),(5,4),(7,4),
                                             (2,5),(3,5),(9,5),(10,5),
                                             (4,6),(7,6),(9,6),
                                             (1,7),(6,7),(8,7),
                                             (2,8),(5,8),(7,8);

-- -------------------------------------------------------
-- 44. ShowTrucks
-- -------------------------------------------------------
INSERT INTO ShowTrucks (ShowId, TruckId) VALUES
                                             (1,2),(1,4),
                                             (2,1),(2,4),
                                             (3,2),(3,5),
                                             (4,1),
                                             (5,2),(5,4),
                                             (6,4),(6,5),
                                             (7,1),
                                             (8,2);

-- -------------------------------------------------------
-- 45. ShowMaterials
-- -------------------------------------------------------
INSERT INTO ShowMaterials (ShowId, MaterialId) VALUES
                                                   (1,1),(1,2),(1,3),(1,6),(1,9),(1,10),(1,12),
                                                   (2,1),(2,2),(2,4),(2,6),(2,8),(2,12),
                                                   (3,1),(3,2),(3,5),(3,6),(3,9),
                                                   (4,1),(4,2),(4,6),(4,7),(4,11),
                                                   (5,1),(5,2),(5,3),(5,6),(5,9),
                                                   (6,1),(6,4),(6,6),(6,8),
                                                   (7,1),(7,2),(7,6),(7,7),
                                                   (8,1),(8,2),(8,6),(8,10);

-- -------------------------------------------------------
-- 46. Contracts (Show x ServiceProvider)
-- -------------------------------------------------------
INSERT INTO Contracts (ShowId, ServiceProviderId, TermsAndConditions) VALUES
                                                                          (1, 1, 'Prestation sono 4h – montage J-1 inclus – démo technique 13/07'),
                                                                          (1, 4, 'Sécurité périmètre – 25 agents – 12h de présence'),
                                                                          (2, 2, 'Sono scène + diffusion – installation J-1'),
                                                                          (2, 3, 'Éclairage scénique 200 projecteurs LED'),
                                                                          (3, 5, 'Sécurité renforcée port – zone pyro – 40 agents'),
                                                                          (4, 1, 'Sono de prestige – régie son Versailles'),
                                                                          (4, 3, 'Éclairage château – mapping vidéo inclus'),
                                                                          (5, 2, 'Sono place de la Bourse – diffusion périmètre'),
                                                                          (6, 7, 'Location groupe électrogène 100kVA'),
                                                                          (7, 6, 'Transport matériel Strasbourg – 2 rotations'),
                                                                          (8, 1, 'Sono promenade – diffusion linéaire'),
                                                                          (8, 8, 'Équipe médicale de permanence – 4h');

-- -------------------------------------------------------
-- 47. SoundTimecodes (Show x Sound)
-- -------------------------------------------------------
INSERT INTO SoundTimecodes (ShowId, SoundId, Start, [End]) VALUES
                                                               (1, 1,    0.0,  900.0),
                                                               (1, 5,  900.0, 2100.0),
                                                               (1, 9, 2100.0, 2340.0),
                                                               (2, 3,    0.0,  480.0),
                                                               (2, 7,  480.0, 1440.0),
                                                               (2, 8, 1440.0, 1620.0),
                                                               (3, 2,    0.0,  210.0),
                                                               (3, 6,  210.0,  990.0),
                                                               (3, 9,  990.0, 1230.0),
                                                               (4, 10,   0.0,  600.0),
                                                               (4, 5,  600.0, 1500.0),
                                                               (4, 8, 1500.0, 1680.0),
                                                               (5, 7,    0.0,  960.0),
                                                               (5, 9,  960.0, 1200.0),
                                                               (8, 10,   0.0,  600.0),
                                                               (8, 5,  600.0, 1320.0),
                                                               (8, 9, 1320.0, 1560.0);

-- -------------------------------------------------------
-- 48. ProductTimecodes (Product x Show)
-- -------------------------------------------------------
INSERT INTO ProductTimecodes (ProductId, ShowId, Start, [End]) VALUES
-- Paris 14 juillet
(3, 1,    0.0,   60.0),
(7, 1,   30.0,  300.0),
(2, 1,  300.0,  600.0),
(1, 1,  600.0, 1200.0),
(8, 1, 1200.0, 1800.0),
(4, 1, 1800.0, 2100.0),
(5, 1, 2100.0, 2200.0),
(6, 1, 2200.0, 2340.0),
-- Lyon festival
(7, 2,    0.0,  240.0),
(2, 2,  240.0,  600.0),
(1, 2,  600.0, 1000.0),
(9, 2, 1000.0, 1200.0),
-- Marseille
(3, 3,    0.0,   90.0),
(7, 3,   60.0,  360.0),
(4, 3,  360.0,  900.0),
(6, 3,  900.0, 1230.0),
-- Gala Versailles
(10,4,    0.0,   60.0),
(2, 4,   60.0,  300.0),
(1, 4,  300.0,  700.0),
(6, 4,  700.0,  900.0),
-- Bordeaux Sylvestre
(7, 5,    0.0,  300.0),
(1, 5,  300.0,  900.0),
(5, 5,  900.0, 1000.0),
(6, 5, 1000.0, 1200.0);

-- -------------------------------------------------------
-- 49. Users
-- -------------------------------------------------------
INSERT INTO Users (Name, Password, Salt, Email, Fonction) VALUES
                                                              ('admin',          '$2a$12$hashed_password_admin',  'salt_admin_abc123',  'admin@pyrofetes.fr',       'Administrateur système'),
                                                              ('jean.dupuis',    '$2a$12$hashed_password_jd',     'salt_jd_xyz789',     'j.dupuis@pyrofetes.fr',    'Directeur commercial'),
                                                              ('sophie.martin',  '$2a$12$hashed_password_sm',     'salt_sm_qrs456',     's.martin@pyrofetes.fr',    'Responsable production'),
                                                              ('marc.leroy',     '$2a$12$hashed_password_ml',     'salt_ml_tuv321',     'm.leroy@pyrofetes.fr',     'Gestionnaire stock'),
                                                              ( 'alice.henry',    '$2a$12$hashed_password_ah',     'salt_ah_wxy654',     'a.henry@pyrofetes.fr',     'Chargée de projets');