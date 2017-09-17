class AddPinchoToVotes < ActiveRecord::Migration[5.0]
  def change
    add_reference :votes, :pincho, foreign_key: true
  end
end
