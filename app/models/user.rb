require 'bcrypt'
class User < ApplicationRecord
  has_many :votes
  has_many :pinchos, through: :votes

  attr_accessor :password

  validates :username, :presence => true, :uniqueness => true, :length => { :in => 3..20 }
  validates :name, :presence => true, :length => { :in => 3..100 }
  validates :password, :confirmation => true
  validates_length_of :password, :in => 6..20, :on => create

  before_save :encrypt_password
  after_save :clear_password

  def encrypt_password
    return unless password.present?

    self.salt = BCrypt::Engine.generate_salt
    self.encrypted_password = BCrypt::Engine.hash_secret(password, salt)
  end

  def clear_password
    self.password = nil
  end
end
