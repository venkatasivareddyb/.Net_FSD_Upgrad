--LVL_1 problem 1
CREATE TABLE Customer (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status VARCHAR(20),   -- Now stores text values
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id)
);
INSERT INTO Customer (customer_id, first_name, last_name) VALUES
(1, 'Alice', 'Smith'),
(2, 'Bob', 'Johnson'),
(3, 'Charlie', 'Brown'),
(4, 'David', 'Williams'),
(5, 'Emma', 'Taylor'),
(6, 'Frank', 'Miller'),
(7, 'Grace', 'Davis'),
(8, 'Henry', 'Wilson'),
(9, 'Ivy', 'Moore'),
(10, 'Jack', 'Anderson');
INSERT INTO Orders (order_id, customer_id, order_date, order_status) VALUES
(101, 1, '2026-03-01', 'Pending'),
(102, 2, '2026-03-02', 'Completed'),
(103, 3, '2026-03-03', 'Pending'),
(104, 4, '2026-03-04', 'Completed'),
(105, 5, '2026-03-05', 'Canceled'),
(106, 6, '2026-03-06', 'Returned'),
(107, 7, '2026-03-07', 'Pending'),
(108, 8, '2026-03-08', 'Completed'),
(109, 9, '2026-03-09', 'Canceled'),
(110, 10, '2026-03-10', 'Returned');
select c.first_name,c.last_name,o.order_id,o.order_date,
o.order_status from Customer c inner join Orders o 
on c.customer_id=o.customer_id where 
o.order_status='Pending' or o.order_status='Completed' 
order by o.order_date desc
--LVL_1 Problem 2
-- Create brands table
CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

-- Create categories table
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

-- Create products table
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);
-- Insert into brands
INSERT INTO brands VALUES
(1, 'Samsung'),
(2, 'Apple'),
(3, 'Sony'),
(4, 'Dell');

-- Insert into categories
INSERT INTO categories VALUES
(1, 'Smartphone'),
(2, 'Laptop'),
(3, 'Television');

-- Insert into products
INSERT INTO products VALUES
(101, 'Galaxy S21', 1, 1, 2021, 799),
(102, 'iPhone 13', 2, 1, 2021, 999),
(103, 'Sony Bravia 55"', 3, 3, 2020, 1200),
(104, 'Dell Inspiron 15', 4, 2, 2022, 650),
(105, 'MacBook Air M1', 2, 2, 2021, 1100),
(106, 'Samsung QLED 65"', 1, 3, 2022, 1500),
(107, 'Sony Xperia 5', 3, 1, 2020, 550),
(108, 'Dell XPS 13', 4, 2, 2021, 1300),
(109, 'Samsung Galaxy A52', 1, 1, 2021, 450), -- won’t appear (price < 500)
(110, 'Apple iPad Pro', 2, 1, 2022, 850);

select p.product_name,b.brand_name,c.category_name,
p.model_year,p.list_price from products p left join 
categories c on p.category_id=c.category_id left join 
brands b on p.brand_id = b.brand_id where p.list_price>=
500 order by list_price
-- LVL2 problem 1
-- Stores table
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

-- Orders table (order_status now VARCHAR)
CREATE TABLE orders_store (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status VARCHAR(20),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

-- Order Items table
CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
-- Stores
INSERT INTO stores VALUES
(1, 'Downtown Store'),
(2, 'Mall Store'),
(3, 'Airport Store');

-- Orders (status as text)
INSERT INTO orders_store VALUES
(101, 1, 'Completed'),
(102, 1, 'Not Completed'),
(103, 2, 'Completed'),
(104, 2, 'Completed'),
(105, 3, 'Completed');

-- Order Items
INSERT INTO order_items VALUES
(1001, 101, 501, 2, 800, 0.10),   -- Downtown
(1002, 101, 502, 1, 1200, 0.05),  -- Downtown
(1003, 102, 503, 3, 500, 0.20),   -- Downtown (Not Completed, excluded)
(1004, 103, 504, 1, 1500, 0.15),  -- Mall
(1005, 103, 505, 2, 700, 0.10),   -- Mall
(1006, 104, 506, 1, 2000, 0.25),  -- Mall
(1007, 105, 507, 4, 600, 0.05),   -- Airport
(1008, 105, 508, 2, 900, 0.10);   -- Airport

select s.store_name,cast(sum(oi.quantity*oi.list_price*(1-oi.discount)) as decimal(12,2)) as total_sales_amount from stores s left join 
orders_store os on s.store_id = os.store_id left join order_items oi on os.order_id = oi.order_id where os.order_status = 'Completed' 
group by s.store_name order by total_sales_amount
--LVL_2 problem 2
-- Product master table
CREATE TABLE product_master (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

-- Store details table
CREATE TABLE store_info (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

-- Stock availability table
CREATE TABLE stock_inventory (
    stock_id INT PRIMARY KEY,
    store_id INT,
    product_id INT,
    available_qty INT,
    FOREIGN KEY (store_id) REFERENCES store_info(store_id),
    FOREIGN KEY (product_id) REFERENCES product_master(product_id)
);

-- Customer orders table
CREATE TABLE customer_orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status VARCHAR(20),
    FOREIGN KEY (store_id) REFERENCES store_info(store_id)
);

-- Order line items table
CREATE TABLE order_line_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    sold_qty INT,
    FOREIGN KEY (order_id) REFERENCES customer_orders(order_id),
    FOREIGN KEY (product_id) REFERENCES product_master(product_id)
);
-- Products
INSERT INTO product_master VALUES
(1, 'Laptop'),
(2, 'Smartphone'),
(3, 'Headphones');

-- Stores
INSERT INTO store_info VALUES
(1, 'Downtown Store'),
(2, 'Mall Store');

-- Stock Inventory
INSERT INTO stock_inventory VALUES
(101, 1, 1, 20),   -- Downtown, Laptop
(102, 1, 2, 50),   -- Downtown, Smartphone
(103, 1, 3, 30),   -- Downtown, Headphones
(104, 2, 1, 15),   -- Mall, Laptop
(105, 2, 2, 40),   -- Mall, Smartphone
(106, 2, 3, 25);   -- Mall, Headphones

-- Orders
INSERT INTO customer_orders VALUES
(201, 1, 'Completed'),
(202, 1, 'Completed'),
(203, 2, 'Completed'),
(204, 2, 'Not Completed');

-- Order Line Items
INSERT INTO order_line_items VALUES
(301, 201, 1, 5),   -- Downtown, Laptop
(302, 201, 2, 10),  -- Downtown, Smartphone
(303, 202, 3, 8),   -- Downtown, Headphones
(304, 203, 1, 7),   -- Mall, Laptop
(305, 203, 2, 12),  -- Mall, Smartphone
(306, 204, 3, 5);   -- Mall, Headphones (Not Completed, excluded)

select p.product_name,s.store_name,si.available_qty as available_stock,
coalesce(sum(o.sold_qty),0) as total_sold from 
product_master p left join stock_inventory si on p.product_id = si.product_id 
inner join store_info s on si.store_id = s.store_id 
inner join customer_orders c on s.store_id = c.store_id 
inner join order_line_items o on c.order_id = o.order_id and o.product_id = p.product_id
group by p.product_name,s.store_name,si.available_qty order by p.product_name 

