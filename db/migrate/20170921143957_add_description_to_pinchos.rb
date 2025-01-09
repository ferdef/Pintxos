class AddDescriptionToPinchos < ActiveRecord::Migration[5.0]
  def change
    add_column :pinchos, :description, :string
  end
end
