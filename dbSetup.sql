-- NOTE feel free to run this and create your accounts table

CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE frogs(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  -- VARCHAR(255)
  name TINYTEXT NOT NULL,
  is_single BOOLEAN NOT NULL DEFAULT true,
  -- VARCHAR(65,535)
  img_url TEXT NOT NULL,
  age TINYINT UNSIGNED NOT NULL
);

-- InSeRt InTo ⚠️this works but it looks dumb
INSERT INTO 
frogs (name, is_single, img_url, age)
VALUES('ziggy', false, 'https://images.unsplash.com/photo-1519874894605-54cfd04fa2fc?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8ZnJvZ3xlbnwwfHwwfHx8Mg%3D%3D', 24);