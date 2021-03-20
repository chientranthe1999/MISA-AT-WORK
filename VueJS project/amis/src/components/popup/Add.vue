<template>
	<div
		class="employee-popup"
		id="employee-popup"
		:class="{ active: modalStatus }"
	>
		<div class="popup__content">
			<div
				id="close-btn"
				@click="this.changeModalStatus"
			><i class="fas fa-times"></i></div>
			<h3 class="popup__title">Thông tin khách hàng</h3>
			<!-- Popup top -->
			<div class="popup__content-top d-flex">
				<div class="customer-avt flex-1">
					<div></div>
					<p>Thêm ảnh ở đây nheeee....</p>
				</div>
				<div class="flex-2">
					<div class="flex-1 d-flex">
						<div class="flex-1 input-swaper">
							<label for="customerCode">Mã khách hàng (<span>*</span>)</label>
							<input
								class="input"
								type="text"
								id="customerCode"
							/>
						</div>
						<div class="flex-1 input-swaper">
							<label for="fullName">Họ và tên (<span>*</span>)</label>
							<input
								class="input"
								type="text"
								id="fullName"
							/>
						</div>
					</div>

					<div class="flex-1 d-flex">
						<div class="flex-1 input-swaper">
							<label for="numberCode">Mã thẻ thành viên (<span>*</span>)</label>
							<input
								class="input"
								type="text"
								id="numberCode"
							/>
						</div>
						<div class="flex-1 input-swaper">
							<label for="customerType">Nhóm khách hàng (<span>*</span>)</label>
							<select
								name=""
								id="customerType"
							>
								<option value="Nhóm khách hàng MISA">
									Nhóm khách hàng MISA
								</option>
								<option value="Khách vip">Khách VIP</option>
							</select>
						</div>
					</div>

					<div class="flex-1 d-flex">
						<div class="flex-1 input-swaper">
							<label for="dateOfBirth">Ngày sinh</label>
							<input
								class="input"
								type="date"
								id="dateOfBirth"
							/>
						</div>
						<div class="flex-1 input-swaper input-gender">
							<label for="">Giới tính (<span>*</span>)</label>
							<div class="radio-swapper">
								<input
									class=""
									type="radio"
									value="1"
									name="gender"
								/><span>Nam</span>
								<input
									class=""
									type="radio"
									value="0"
									name="gender"
									checked
								/><span>Nữ</span>
								<input
									class=""
									type="radio"
									value="3"
									name="gender"
								/>
								<span>Khác</span>
							</div>
						</div>
					</div>
				</div>
			</div>
			<!-- Popup middle -->
			<div class="popup__content-middle">
				<div class="d-flex">
					<div class="flex-2">
						<label for="email">Email (<span>*</span>)</label>
						<input
							class="input"
							type="text"
							placeholder="example@domain.com"
							id="email"
						/>
					</div>
					<div class="flex-1">
						<label for="">Số điện thoại (<span>*</span>)</label>
						<input
							class="input"
							type="text"
							placeholder=""
							id="phoneNumber"
						/>
					</div>
				</div>
				<div class="d-flex">
					<div class="flex-2">
						<label for="">Tên Công Ty</label>
						<input
							class="input"
							type="text"
							placeholder=""
						/>
					</div>
					<div class="flex-1">
						<label for="">Mã số thuế</label>
						<input
							class="input"
							type="text"
							placeholder="Mã số thuế công ty"
						/>
					</div>
				</div>
				<div class="flex-1">
					<label for="">Địa chỉ</label>
					<input
						class="input"
						type="text"
						placeholder="Địa chỉ"
					/>
				</div>
			</div>
			<!-- Popup bottom -->
			<div class="popup__content-bottom d-flex">
				<div
					id="cancel-btn"
					class="btn"
				>Hủy</div>
				<div
					id="delete-btn"
					class="btn"
					data-id=""
				>Xóa</div>
				<div
					id="save-btn"
					class="btn d-flex"
					data-id=""
				>
					<span><i class="far fa-save"></i></span> Save
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: "Add",
	props: {
		modalStatus: Boolean,
		changeModalStatus: Function,
	},
};
</script>

<style scoped lang="scss">
$green: #01b075;
.employee-popup {
	display: none;
	position: fixed;
	top: 0;
	right: 0;
	background-color: rgba(0, 0, 0, 0.5);
	width: 100%;
	height: 100vh;

	label {
		display: block;
		margin-bottom: 5px;
	}

	label > span {
		color: red;
	}

	input[type="text"],
	input[type="date"] {
		width: 100%;
		padding-left: 20px;
	}

	.input-swaper:nth-child(1) {
		margin-right: 10px;
	}

	input[type="radio"] {
		transform: scale(1.5);
	}

	/*-------- Popup Title--------*/

	.popup__title {
		padding: 0 24px;
		text-transform: uppercase;
		font-size: 24px;
		margin: 20px 0;
	}

	/*-------- Popup CSS Main--------*/
	.popup__content {
		background-color: #fff;
		width: 730px;
		border-radius: 5px;
		position: relative;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		overflow: hidden;
		/*-------- Popup top CSS --------*/
		&-top {
			padding: 0 24px;
			.customer-avt {
				text-align: center;
				> div {
					margin: 0 auto;
					background-image: url("../../assets/img/default-avatar.jpg");
					background-size: contain;
					width: 200px;
					height: 200px;
					border-radius: 50%;
					border: 1px solid #e5e5e5;
					// margin-bottom: 10px;
				}
				> p {
					margin-top: 10px;
				}
			}
			.flex-2 > div {
				margin-bottom: 20px;
			}
			.input-gender {
				// Overide .input css of common file
				.input {
					margin: 0;
				}
				.radio-swapper {
					$hw: 40px;
					height: $hw;
					line-height: $hw;
					input:nth-child(1) {
						margin-left: 5px;
					}
					input + span {
						display: inline-block;
						height: $hw;
						line-height: $hw;
						margin-right: 10px;
						margin-left: 5px;
					}
				}
			}
		}

		/*-------- Popup middle CSS --------*/
		&-middle {
			padding: 0 24px;
			> div {
				margin-bottom: 20px;
				> div:nth-child(1) {
					margin-right: 10px;
				}
			}
		}
		/*-------- Popup bottom CSS --------*/
		&-bottom {
			background-color: #e5e5e5;
			height: 60px;
			align-items: center;
			padding: 0 25px;
		}
	}

	/*-------- Button CSS --------*/
	#save-btn {
		height: 40px;
		padding: 8px 16px;
		border-radius: 4px;
		align-items: center;
		background-color: $green;
		color: white;
		> span {
			margin-right: 5px;
		}
	}

	#cancel-btn,
	#delete-btn {
		height: 40px;
		line-height: 40px;
		padding: 0 20px;
		margin-left: auto;
		margin-right: 16px;
	}
	#cancel-btn:hover {
		background-color: #bbb;
	}

	#delete-btn {
		background-color: #f65454;
		margin-left: 0;
		color: #fff;
		display: none;
	}

	#close-btn {
		$hw: 30px;
		height: $hw;
		width: $hw;
		line-height: $hw;
		text-align: center;
		font-size: 20px;
		border-radius: 4px;
		cursor: pointer;
		position: absolute;
		top: 0;
		right: 0;
	}

	#close-btn:hover {
		background-color: #e5e5e5;
	}

	/*-------- Select tag CSS --------*/
	#customerType {
		width: 100%;
		height: 40px;
		border: 1px solid #bbb;
		border-radius: 5px;
		padding-left: 20px;
	}
}

.employee-popup.active {
	display: block;
}
</style>
