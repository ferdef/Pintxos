class AddPasswordToUser < ActiveRecord::Migration[5.0]
  def change
    add_column :users, :encrypted_password, :string
    add_column :users, :salt, :string
  end
end
